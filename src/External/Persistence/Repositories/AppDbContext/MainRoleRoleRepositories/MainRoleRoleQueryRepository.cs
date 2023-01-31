using System;
using System.Linq.Expressions;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.MainRoleRoleRepositories;
using Persistence.Repositories.GenericRepositories.AppDbContext;

namespace Persistence.Repositories.AppDbContext.MainRoleRoleRepositories
{
    public class MainRoleRoleQueryRepository : AppQueryRepository<MainRoleRole>, IMainRoleRoleQueryRepository
    {
        public MainRoleRoleQueryRepository(Context.AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

