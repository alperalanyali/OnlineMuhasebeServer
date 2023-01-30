using System;
using Domain.AppEntities;
using Domain.AppEntities.Identity;

namespace Application.Services.AppServices
{
	public interface IMainRoleService
	{
        Task<MainRole> GetByTitleAndCompany(string title, string companyId);

        Task<IList<MainRole>> GetStaticMainRoleAsync();
        Task CreateAsync(MainRole mainRole,CancellationToken cancellationToken);
        Task CreateRangeAsync(List<MainRole> mainRoles,CancellationToken cancellationToken);
    }
}

