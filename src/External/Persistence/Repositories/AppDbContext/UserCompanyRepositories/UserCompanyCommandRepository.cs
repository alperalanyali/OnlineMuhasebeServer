using System;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.UserCompanyRepositories;
using Persistence.Repositories.GenericRepositories.AppDbContext;

namespace Persistence.Repositories.AppDbContext.UserCompanyRepositories
{
    public class UserCompanyCommandRepository : AppCommandRepository<AppUserCompany>, IUserCompanyCommandRepository
    {
        public UserCompanyCommandRepository(Context.AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

