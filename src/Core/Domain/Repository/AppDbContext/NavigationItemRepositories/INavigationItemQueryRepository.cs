using System;
using Domain.AppEntities;
using Domain.Repository.GenericRepositories;

namespace Domain.Repository.AppDbContext.NavigationItemRepositories
{
	public interface INavigationItemQueryRepository: IQueryGenericRepository<NavigationItem>
	{
	}
}

