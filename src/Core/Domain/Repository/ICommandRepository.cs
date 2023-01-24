using System;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
	public interface ICommandRepository<T> : IRepository<T> where T :Entity
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

