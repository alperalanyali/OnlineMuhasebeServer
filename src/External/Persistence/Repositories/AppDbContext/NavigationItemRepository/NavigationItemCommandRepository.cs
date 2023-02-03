using System;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.NavigationItemRepositories;
using Persistence.Repositories.GenericRepositories.AppDbContext;

namespace Persistence.Repositories.AppDbContext.NavigationItemRepository
{
    public class NavigationItemCommandRepository : AppCommandRepository<NavigationItem>, INavigationItemCommandRepository
    {
        public NavigationItemCommandRepository(Context.AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

