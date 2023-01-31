using System;
using Domain.AppEntities;
using Domain.AppEntities.Identity;

namespace Application.Services.AppServices
{
	public interface IMainRoleService
	{
        Task<MainRole> GetByTitleAndCompany(string title, string companyId);
        Task<MainRole> GetById(string Id);
        Task<IList<MainRole>> GetMainRoleAsync();
        Task CreateAsync(MainRole mainRole,CancellationToken cancellationToken);
        Task CreateRangeAsync(List<MainRole> mainRoles,CancellationToken cancellationToken);
        Task DeleteMainRole(string id,CancellationToken cancellationToken);
        Task UpdateAsync(MainRole mainRole,CancellationToken cancellationToken);

    }
}

