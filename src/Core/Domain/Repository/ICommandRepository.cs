using System;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
	public interface ICommandRepository<T> : IRepository<T> where T :Entity
	{
		
		Task AddAsync(T entity,CancellationToken cancellationToken);
		Task AddRangeAsnyc(IEnumerable<T> entities, CancellationToken cancellationToken);
		void Update(T entity);
		void UpdateRange(IEnumerable<T> entities);
		Task RemoveById(string id);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
	}
}

