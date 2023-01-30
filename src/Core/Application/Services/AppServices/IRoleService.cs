using System;
using Application.Features.AppFeatures.AppUserFeatures.RoleFeatures.Commands.CreateRole;
using Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using Domain.AppEntities.Identity;

namespace Application.Services.AppServices
{
	public interface IRoleService
	{
		Task<IList<AppRole>> GetAllRolesAsync();
		Task<AppRole> GetById(string id);
		Task AddAsync(CreateRoleCommand request);
        Task AddRangeAsync(IEnumerable<AppRole> roles);
        Task UpdateAsync(AppRole role);
		Task DeleteByIdAsync(string id);
		Task<AppRole> GetByCode(string code);

		
	}
}

