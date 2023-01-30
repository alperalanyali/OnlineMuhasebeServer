
using System;
using System.Linq.Expressions;
using Domain.Abstractions;
using Domain.Repository.GenericRepositories;

namespace Domain.Repository
{
	public interface ICompanyDbQueryRepository<T>: IRepository<T>, IQueryGenericRepository<T>
        where T: Entity 
	{

	}
}

