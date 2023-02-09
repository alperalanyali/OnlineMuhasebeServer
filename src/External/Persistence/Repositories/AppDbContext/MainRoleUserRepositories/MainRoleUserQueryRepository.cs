using System;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.MainRoleUserRepositories;
using Persistence.Repositories.GenericRepositories.AppDbContext;

namespace Persistence.Repositories.AppDbContext.MainRoleUserRepositories
{
    public class MainRoleUserQueryRepository : AppQueryRepository<MainRoleUser>, IMainRoleUserQueryRepository
    {
        public MainRoleUserQueryRepository(Context.AppDbContext dbContext) : base(dbContext)
        {
        }
     
    }
}

