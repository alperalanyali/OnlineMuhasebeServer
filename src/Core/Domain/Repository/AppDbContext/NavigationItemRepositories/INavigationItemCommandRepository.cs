using System;
using Domain.AppEntities;
using Domain.Repository.GenericRepositories.AppDbContext;

namespace Domain.Repository.AppDbContext.NavigationItemRepositories
{
	public interface INavigationItemCommandRepository:IAppCommandRepository<NavigationItem>
	{
	}
}

