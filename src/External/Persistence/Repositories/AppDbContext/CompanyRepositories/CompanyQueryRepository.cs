using System;
using Domain.AppEntities;
using Domain.Repository.AppDbContext.CompanyRepositories;
using Persistence.Repositories.GenericRepositories.AppDbContext;

namespace Persistence.Repositories.AppDbContext.CompanyRepositories
{
    public sealed class CompanyQueryRepository : AppQueryRepository<Company>, ICompanyQueryRepository
    {
        public CompanyQueryRepository(Context.AppDbContext context) : base(context)
        {
        }
    }
}

