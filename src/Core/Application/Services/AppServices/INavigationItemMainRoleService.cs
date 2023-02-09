using System;
using Domain.AppEntities;

namespace Application.Services.AppServices
{
	public interface INavigationItemMainRoleService
	{
        Task<NavigationItemMainRole> GetById(string Id);
        Task<IList<NavigationItemMainRole>> GetNavigationItemMainRoles(string filter);
        Task<IList<NavigationItemMainRole>> GetNavigationItemMainRolesByMainRoleId(string mainRoleId);
        Task<bool> CheckAlreadyNavigationItemMainRoleExist(string navigationItemId, string mainRoleId);
        Task CreateAsync(NavigationItemMainRole navigationItemMainRole, CancellationToken cancellationToken);
        Task DeleteNavigationItemMainRoleById(string id, CancellationToken cancellationToken);
        Task UpdateAsync(NavigationItemMainRole navigationItemMainRole, CancellationToken cancellationToken);
    }
}

