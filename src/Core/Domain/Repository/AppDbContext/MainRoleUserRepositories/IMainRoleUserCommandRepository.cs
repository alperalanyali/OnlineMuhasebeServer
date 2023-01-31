using System;
using Domain.AppEntities;
using Domain.Repository.GenericRepositories.AppDbContext;

namespace Domain.Repository.AppDbContext.MainRoleUserRepositories
{
	public interface IMainRoleUserCommandRepository: IAppCommandRepository<MainRoleUser>
	{
	}
}

