using System;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.NavigationItemMainRoleRepositories;
using Persistence.Repositories.GenericRepositories.AppDbContext;

namespace Persistence.Repositories.AppDbContext.NavigationItemMainRoleRepositories
{
    public class NavigationItemMainRoleCommandRepository : AppCommandRepository<NavigationItemMainRole>, INavigationItemMainRoleCommandRepository
    {
        public NavigationItemMainRoleCommandRepository(Context.AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

