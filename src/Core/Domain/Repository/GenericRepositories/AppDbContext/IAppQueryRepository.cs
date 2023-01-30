using System;
using Domain.Abstractions;

namespace Domain.Repository.GenericRepositories.AppDbContext
{
	public interface IAppQueryRepository<T>: IQueryGenericRepository<T>, IRepository<T>
        where T :Entity 
	{
	}
}

