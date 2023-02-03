using System;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.NavigationItemRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.GenericRepositories.AppDbContext;

namespace Persistence.Repositories.AppDbContext.NavigationItemRepository
{
    public class NavigationItemQueryRepository : AppQueryRepository<NavigationItem>, INavigationItemQueryRepository
    {
        public NavigationItemQueryRepository(Context.AppDbContext context) : base(context)
        {
        }   
    }
}

