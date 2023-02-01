using System;
using Domain.AppEntities;
using Domain.AppEntities.Identity;

namespace Application.Services.AppServices
{
	public interface IAuthService
	{
		Task<AppUser> GetByEmailOrUsernameAsync(string emailOrUsername);
		Task<bool> CheckPasswordAsync(AppUser user,string password);
		Task<IList<AppUserCompany>> GetCompanyListAsync(string userId);
		Task<IList<string>> GetRolesByUserIdAndCompany(string userId, string companyId);
	}
}

