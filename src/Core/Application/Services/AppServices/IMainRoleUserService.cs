using System;
using Domain.AppEntities;

namespace Application.Services.AppServices
{
	public interface IMainRoleUserService
	{       
        Task<MainRoleUser> GetById(string Id);
        Task<IList<MainRoleUser>> GetMainRolUsereAsync();
        Task CreateAsync(MainRoleUser mainRole, CancellationToken cancellationToken);
        Task CreateRangeAsync(List<MainRoleUser> mainRoles, CancellationToken cancellationToken);
        Task DeleteMainRoleUser(string id, CancellationToken cancellationToken);
        Task UpdateAsync(MainRoleUser mainRole, CancellationToken cancellationToken);
        Task<MainRoleUser> GetRolesByUserIdAndCompany(string userId, string companyId);
    }
}

