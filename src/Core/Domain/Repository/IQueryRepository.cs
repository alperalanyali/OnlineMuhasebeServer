
using System;
using System.Linq.Expressions;
using Domain.Abstractions;

namespace Domain.Repository
{
	public interface IQueryRepository<T> where T: Entity
	{
		IQueryable<T> GetAll();
		IQueryable<T> GetWhere(Expression<Func<T,bool>> expression);
		Task<T> GetById(string id);
		Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression);
		Task<T> GetFirst();
	}
}

