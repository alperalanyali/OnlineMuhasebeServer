using System;
using Domain.AppEntities;

namespace Application.Services.AppServices
{
	public interface IUserCompanyService
	{
        Task<IList<AppUserCompany>> GetAllUserCompany(string filter);
        Task<AppUserCompany> GetUserCompanyById(string id);
        Task CreateAsync(AppUserCompany userCompany,CancellationToken cancellationToken);
        Task UpdateAsync(AppUserCompany userCompany,CancellationToken cancellationToken);
        Task DeleteById(string userCompanyId,CancellationToken cancellationTokenw);
        Task<IList<AppUserCompany>> GetCompanyListByUserId(string userId);
        Task<AppUserCompany> GetUserCompanyByUserIdAndCompanyId(string userId, string companyId);
    }
}

