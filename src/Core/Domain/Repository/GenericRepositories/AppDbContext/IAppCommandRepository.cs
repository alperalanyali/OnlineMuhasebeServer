using System;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository.GenericRepositories.AppDbContext
{
	public interface IAppCommandRepository<T> : ICommandGenericRepository<T>, IRepository<T>
        where T:Entity
	{
    
    }
}

