using System;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.MainRoleUserRepositories;
using Persistence.Repositories.GenericRepositories.AppDbContext;

namespace Persistence.Repositories.AppDbContext.MainRoleUserRepositories
{
    public class MainRoleUserCommandRepository : AppCommandRepository<MainRoleUser>, IMainRoleUserCommandRepository
    {
        public MainRoleUserCommandRepository(Context.AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

