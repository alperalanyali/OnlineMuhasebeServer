using System;
using System.Linq.Expressions;
using Domain.Abstractions;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace Domain.Repository.GenericRepositories
{
	public interface IQueryGenericRepository<T>
		where T:Entity
	{
        Task<PaginationResult<T>> GetAllPagination(int pageNumber=1, int pageSize=10, Expression<Func<T, bool>> orderExpression = null,bool isOrderDesc = false);
        Task<PaginationResult<T>> GetWhere(Expression<Func<T, bool>> expression,int pageNumber, int pageSize, Expression<Func<T, bool>> orderExpression = null, bool isOrderDesc = false);
        IQueryable<T> GetAll(bool isTracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true);
        Task<T> GetById(string id, bool isTracking = true);
        Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression, bool isTracking = true);
        Task<T> GetFirst(bool isTracking = true);
    }
}

