using System;
using Domain.Abstractions;
using Domain.Repository.GenericRepositories;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
	public interface ICompanyDbCommandRepository<T> : IRepository<T>, ICommandGenericRepository<T>
        where T :Entity
	{
	}
}

