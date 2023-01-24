using System;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
	public interface IRepository<T> where T :Entity
	{
        void SetDbContextInst(DbContext context);
        DbSet<T> Entity { get; set; }
    }
}

