using System;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.UserCompanyRepositories;
using Persistence.Repositories.GenericRepositories.AppDbContext;

namespace Persistence.Repositories.AppDbContext.UserCompanyRepositories
{
    public class UserCompanyQueryRepository : AppQueryRepository<AppUserCompany>, IUserCompanyQueryRepository
    {
        public UserCompanyQueryRepository(Context.AppDbContext context) : base(context)
        {
        }
    }
}

