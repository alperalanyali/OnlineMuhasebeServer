using System;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
	public interface IUnitOfWork
	{
        void SetDbContextInst(DbContext context);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

