using System;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.MainRoleRepository;
using Domain.Repository.GenericRepositories;
using Persistence.Repositories.GenericRepositories.AppDbContext;

namespace Persistence.Repositories.AppDbContext.MainRoleRepository
{
    public class MainRoleCommandRepository : AppCommandRepository<MainRole>, IMainRoleCommandRepository
    {
        public MainRoleCommandRepository(Context.AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

