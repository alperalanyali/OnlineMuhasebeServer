using System;
using Domain.Abstractions;
using Domain.Repository.GenericRepositories.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories.GenericRepositories.AppDbContext
{
    public  class AppCommandRepository<T> : IAppCommandRepository<T>
        where T : Entity
    {

        private static readonly Func<Context.AppDbContext, string, Task<T>> GetById =
         EF.CompileAsyncQuery((Context.AppDbContext context, string id) => context.Set<T>().FirstOrDefault(p => p.Id == id));
        private readonly Context.AppDbContext _dbContext;

        public AppCommandRepository(Context.AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Entity = _dbContext.Set<T>();
        }

        public DbSet<T> Entity { get; set; }

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
            var entity = await GetById(_dbContext, id);
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

