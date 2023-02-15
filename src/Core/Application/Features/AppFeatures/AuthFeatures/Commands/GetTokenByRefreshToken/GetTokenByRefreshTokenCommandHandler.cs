using System;
using Application.Abstractions;
using Application.Features.AuthFeatures.Commands.Login;
using Application.Messaging;
using Application.Services.AppServices;
using Domain.AppEntities;
using Domain.AppEntities.Identity;
using Domain.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.AppFeatures.AuthFeatures.Commands.GetTokenByRefreshToken
{
	public sealed class GetTokenByRefreshTokenCommandHandler :ICommandHandler<GetTokenByRefreshTokenCommand,GetTokenByRefreshTokenCommandResponse>
	{
        private readonly IJwtProvider _jwtProvider;
        private readonly IAuthService _authService;
        private readonly UserManager<AppUser> _userManager;
        public GetTokenByRefreshTokenCommandHandler(IJwtProvider jwtProvider, IAuthService authService,UserManager<AppUser> userManager)
        {
            _jwtProvider = jwtProvider;
            _authService = authService;
            _userManager = userManager;
        }
        public async Task<GetTokenByRefreshTokenCommandResponse> Handle(GetTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }

            if (user.RefreshToken != request.RefreshToken)
                throw new Exception("Refresh Token geçerli değil");

            IList<AppUserCompany> companies = await _authService.GetCompanyListAsync(user.Id);

            IList<CompanyDto> companyDtos = companies.Select(s => new CompanyDto(s.Company.Id, s.Company.Name)).ToList();

            if (companies.Count == 0) throw new Exception("Kullanıcı herhangi bir sirket kayitli degilsiniz");

            List<string> roles = new();
            GetTokenByRefreshTokenCommandResponse response = new GetTokenByRefreshTokenCommandResponse(
                Email: user.Email,
                FullName: user.FullName,
                UserId: user.Id,
                Token: await _jwtProvider.CreateToken(user),
                Companies: companyDtos,
                Company: companyDtos.Where(p => p.CompanyId == request.CompanyId).FirstOrDefault(),
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

