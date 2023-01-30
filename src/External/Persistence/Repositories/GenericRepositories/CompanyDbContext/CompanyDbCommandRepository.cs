using System;
using Domain.Repository;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Threading;

namespace Persistence.Repositories.GenericRepositories.CompanyDbContext
{
    public class CompanyDbCommandRepository<T> : ICompanyDbCommandRepository<T> where T : Entity
    {

        private static readonly Func<Context.CompanyDbContext, string, Task<T>> GetById =
            EF.CompileAsyncQuery((Context.CompanyDbContext context, string id) => context.Set<T>().FirstOrDefault(p => p.Id == id));  
            
          
        private Context.CompanyDbContext _dbContext;

        public DbSet<T> Entity { get; set; }
        

        public void SetDbContextInst(DbContext context)
        {
            _dbContext = (Context.CompanyDbContext)context;
            Entity = _dbContext.Set<T>();
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await Entity.AddAsync(entity, cancellationToken);
        }

        public async Task AddRangeAsnyc(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            await Entity.AddRangeAsync(entities, cancellationToken);
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

