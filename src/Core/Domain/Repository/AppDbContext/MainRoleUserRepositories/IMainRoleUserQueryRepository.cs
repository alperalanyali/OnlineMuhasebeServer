using System;
using Domain.AppEntities;
using Domain.Repository.GenericRepositories;

namespace Domain.Repository.AppDbContext.MainRoleUserRepositories
{
	public interface IMainRoleUserQueryRepository: IQueryGenericRepository<MainRoleUser>
    {
		Task<string> GetMainRoleUserByUserId(string userId);
	}
}

