using System;
using Domain.Abstractions;

namespace Domain.Repository
{
	public interface ICommandRepository<T>  where T :Entity
	{
		Task AddAsync(T entity);
		Task AddRangeAsnyc(IEnumerable<T> entities);
		void Update(T entity);
		void UpdateRange(IEnumerable<T> entities);
		Task RemoveById(string id);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
	}
}

