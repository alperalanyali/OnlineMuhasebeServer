using System;
using Application.Abstractions;
using Application.Messaging;
using Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppFeatures.AppUserFeatures.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginCommandResponse> // // Validation özelliğinden önceki hali IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<AppUser> _userManager;


        public LoginCommandHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
        }

        public async Task<LoginCommandResponse> Handle(/*LoginRequest*/LoginCommand request, CancellationToken cancellationToken)
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
            LoginCommandResponse response = new LoginCommandResponse(
                user.Email,
                user.FullName,
                user.Id,
                 await _jwtProvider.CreateToken(user, roles));
            //{
            //    Email = user.Email,
            //    FullName = user.FullName,
            //    UserId = user.Id,
            //    Token = await _jwtProvider.CreateToken(user, roles)
            //};

            return response;
        }
    }
}

