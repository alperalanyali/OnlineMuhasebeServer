using System;
using Domain.AppEntities.Identity;
using Domain.Dtos;

namespace Application.Abstractions
{
	public interface IJwtProvider
	{
		Task<TokenRefreshTokenDto> CreateToken(AppUser user);
	}
}

