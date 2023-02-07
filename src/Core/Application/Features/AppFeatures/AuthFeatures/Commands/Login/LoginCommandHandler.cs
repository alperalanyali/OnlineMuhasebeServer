using System;
using Application.Abstractions;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.AppEntities;
using Domain.AppEntities.Identity;
using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AuthFeatures.Commands.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginCommandResponse> // // Validation özelliğinden önceki hali IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly IAuthService _authService;        
        public LoginCommandHandler(IJwtProvider jwtProvider, IAuthService authService )
        {
            _jwtProvider = jwtProvider;            
            _authService = authService;            
        }

        public async Task<LoginCommandResponse> Handle(/*LoginRequest*/LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await _authService.GetByEmailOrUsernameAsync(request.EmailOrUsername);
            if(user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }

            var checkUser = await _authService.CheckPasswordAsync(user, request.Password);
            if (!checkUser)
                throw new Exception("Şifreniz yanlış");

            IList<AppUserCompany> companies =await _authService.GetCompanyListAsync(user.Id);

            IList<CompanyDto> companyDtos = companies.Select(s => new CompanyDto(  s.Company.Id, s.Company.Name )).ToList();

            if (companies.Count == 0) throw new Exception("Kullanıcı herhangi bir sirket kayitli degilsiniz");

            List<string> roles = new();
            LoginCommandResponse response = new LoginCommandResponse(
                Email:user.Email,
                FullName:user.FullName,
                UserId:user.Id,
                Token:await _jwtProvider.CreateToken(user),                
                Companies:companyDtos,
                Company: companyDtos[0],
                Year: DateTime.Now.Year
                );
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

