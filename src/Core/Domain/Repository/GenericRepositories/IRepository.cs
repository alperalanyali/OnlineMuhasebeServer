using System;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository.GenericRepositories
{
	public interface IRepository<T>
        where T :Entity
	{
        public DbSet<T> Entity { get; set; }
    }
}

