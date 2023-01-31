using System;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.MainRoleRoleRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.GenericRepositories.AppDbContext;

namespace Persistence.Repositories.AppDbContext.MainRoleRoleRepositories
{
    public class MainRoleRoleCommandRepository : AppCommandRepository<MainRoleRole>, IMainRoleRoleCommand
    {
        public MainRoleRoleCommandRepository(Context.AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

