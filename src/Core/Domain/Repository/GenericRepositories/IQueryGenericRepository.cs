using System;
using System.Linq.Expressions;
using Domain.Abstractions;

namespace Domain.Repository.GenericRepositories
{
	public interface IQueryGenericRepository<T>
		where T:Entity
	{
        IQueryable<T> GetAll(bool isTracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true);
        Task<T> GetById(string id, bool isTracking = true);
        Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression, bool isTracking = true);
        Task<T> GetFirst(bool isTracking = true);
    }
}

