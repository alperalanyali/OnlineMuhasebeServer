using System;
namespace Domain
{
	public interface IUnitOfWork
	{
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

