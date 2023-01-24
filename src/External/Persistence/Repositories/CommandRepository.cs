using System;
using Domain.Repository;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CommandRepository<T> : ICommandRepository<T> where T : Entity
    {

        private static readonly Func<CompanyDbContext, string, Task<T>> GetById =
            EF.CompileAsyncQuery((CompanyDbContext context, string id) => context.Set<T>().FirstOrDefault(p => p.Id == id));  
            
          
        private CompanyDbContext _dbContext;

        public DbSet<T> Entity { get; set; }
        

        public void SetDbContextInst(DbContext context)
        {
            _dbContext = (CompanyDbContext)context;
            Entity = _dbContext.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await Entity.AddAsync(entity);
        }

        public async Task AddRangeAsnyc(IEnumerable<T> entities)
        {
            await Entity.AddRangeAsync(entities);
        }

       

        public void Remove(T entity)
        {
            Entity.Remove(entity);
        }

        public async Task RemoveById(string id)
        {
            var entity = await GetById(_dbContext,id);
            Entity.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Entity.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Entity.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            Entity.UpdateRange(entities);
        }
    }
}

