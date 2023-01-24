using System;
using Domain;
using Domain.AppEntities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence
{
    public sealed class ContextService : IContextService
    {
        private readonly AppDbContext _appContext;

        public ContextService(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public DbContext CreateDBContextInstance(string companyId)
        {
            Company company = _appContext.Set<Company>().Find(companyId);
            return new CompanyDbContext(company);
        }
    }
}

