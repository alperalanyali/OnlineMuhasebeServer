using System;
using Domain.AppEntities;

namespace Application.Services.AppServices
{
	public interface IMainRoleRoleService
	{
        Task<MainRoleRole> GetById(string Id);
        Task<IList<MainRoleRole>> GetMainRoleRoleAsync();
        Task CreateAsync(MainRoleRole mainRole, CancellationToken cancellationToken);
        Task CreateRangeAsync(List<MainRoleRole> mainRoles, CancellationToken cancellationToken);
        Task DeleteMainRoleRole(string id, CancellationToken cancellationToken);
        Task UpdateAsync(MainRoleRole mainRole, CancellationToken cancellationToken);
    }
}

