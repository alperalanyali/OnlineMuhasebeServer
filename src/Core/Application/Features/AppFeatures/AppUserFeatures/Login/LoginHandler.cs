using System;
using Application.Abstractions;
using Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppFeatures.AppUserFeatures.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<AppUser> _userManager;


        public LoginHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.Users.Where(p => p.Email == request.EmailOrUsername
                                                            || p.UserName == request.EmailOrUsername).FirstOrDefaultAsync();
            if(user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }

            var checkUser = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!checkUser)
                throw new Exception("Şifreniz yanlış");
            List<string> roles = new();
            LoginResponse response = new LoginResponse()
            {
                Email = user.Email,
                FullName = user.FullName,
                UserId = user.Id,
                Token = await _jwtProvider.CreateToken(user, roles)
            };

            return response;
        }
    }
}

