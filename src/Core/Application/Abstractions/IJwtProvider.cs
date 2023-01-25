using System;
using Domain.AppEntities.Identity;

namespace Application.Abstractions
{
	public interface IJwtProvider
	{
		Task<string> CreateToken(AppUser user,List<string> roles);
	}
}

