using System;
using Domain;
using Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.UnitOfWorks
{
    public sealed class CompanyDbUnitOfWork : ICompanyDbUnitOfWork
    {
        private CompanyDbContext _context;
        public void SetDbContextInst(DbContext context)
        {
            _context = (CompanyDbContext)context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            int count =  await _context.SaveChangesAsync(cancellationToken);
            return count;
        }
    }
}

