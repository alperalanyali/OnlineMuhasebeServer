using System;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.MainRoleRepository;
using Domain.Repository.GenericRepositories.AppDbContext;
using Persistence.Repositories.GenericRepositories.AppDbContext;

namespace Persistence.Repositories.AppDbContext.MainRoleRepository
{
    public sealed class MainRoleQueryRepository : AppQueryRepository<MainRole>, IMainRoleQueryRepository
    {
        public MainRoleQueryRepository(Context.AppDbContext context) : base(context)
        {
        }
    }
}

