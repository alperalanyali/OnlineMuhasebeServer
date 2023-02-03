using System;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.NavigationItemMainRoleRepositories;
using Persistence.Repositories.GenericRepositories.AppDbContext;

namespace Persistence.Repositories.AppDbContext.NavigationItemMainRoleRepositories
{
    public class NavigationItemMainRoleQueryRepository : AppQueryRepository<NavigationItemMainRole>, INavigationItemMainRoleQueryRepository
    {
        public NavigationItemMainRoleQueryRepository(Context.AppDbContext context) : base(context)
        {
        }
    }
}

