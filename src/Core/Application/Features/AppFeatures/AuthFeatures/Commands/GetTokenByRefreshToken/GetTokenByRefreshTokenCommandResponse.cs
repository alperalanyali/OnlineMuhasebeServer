using System;
using Domain.Dtos;

namespace Application.Features.AppFeatures.AuthFeatures.Commands.GetTokenByRefreshToken
{
	public sealed record GetTokenByRefreshTokenCommandResponse(
           TokenRefreshTokenDto Token,
            string Email,
            string UserId,
            string FullName,
            IList<CompanyDto> Companies,
            CompanyDto Company,
            int Year
        );
	
}

