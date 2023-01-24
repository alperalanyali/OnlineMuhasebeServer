using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private CompanyDbContext _context;
        public void SetDbContextInst(DbContext context)
        {
            _context = (CompanyDbContext)context;
        }

        public async Task<int> SaveChangesAsync()
        {
            int count =  await _context.SaveChangesAsync();
            return count;
        }
    }
}

