using System;
using Domain.AppEntities;
using Domain.Repository.GenericRepositories;

namespace Domain.Repository.AppDbContext.MainRoleRepository
{
	public interface IMainRoleCommandRepository :ICommandGenericRepository<MainRole>
	{
	}
}

