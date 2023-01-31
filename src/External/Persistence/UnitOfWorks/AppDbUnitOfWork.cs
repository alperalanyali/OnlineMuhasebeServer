using System;
using Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.UnitOfWorks
{
    public sealed class AppDbUnitOfWork : IAppUnitOfWork
    {
        private readonly AppDbContext _context;

        public AppDbUnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int count = await _context.SaveChangesAsync(cancellationToken);
            return count;
        }

    }
}

