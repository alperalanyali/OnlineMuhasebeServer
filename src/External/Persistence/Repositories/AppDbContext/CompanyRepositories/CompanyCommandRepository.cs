using System;
using Domain.AppEntities;
using Domain.Repository;
using Domain.Repository.AppDbContext.CompanyRepositories;
using Persistence.Repositories.GenericRepositories.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories.AppDbContext.CompanyRepositories
{
    public sealed class CompanyCommandRepository : AppCommandRepository<Company>, ICompanyCommandRepository
    {
        public CompanyCommandRepository(Context.AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

