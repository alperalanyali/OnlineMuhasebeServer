using System;
using Domain.Abstractions;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq.Expressions;
namespace Persistence.Repositories
{
    public class QueryRepository<T> : IQueryRepository<T> where T : Entity
    {
        private CompanyDbContext _context;

        private static readonly Func<CompanyDbContext, string, Task<T>> GetByIdCompiled =
            EF.CompileAsyncQuery((CompanyDbContext context, string id) => context.Set<T>().FirstOrDefault(p => p.Id == id));

        private static readonly Func<CompanyDbContext, Task<T>> GetFirstCompiled =
    EF.CompileAsyncQuery((CompanyDbContext context) => context.Set<T>().FirstOrDefault());

        private static readonly Func<CompanyDbContext, Expression<Func<T, bool>>, Task<T>> GetFirstByExpressionCompiled =
EF.CompileAsyncQuery((CompanyDbContext context, Expression<Func<T, bool>> expression) => context.Set<T>().FirstOrDefault(expression));

        public DbSet<T> Entity { get ; set; }

        public void SetDbContextInst(DbContext context)
        {
            _context = (CompanyDbContext)context;

            Entity = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return Entity.AsQueryable();
        }

        public async Task<T> GetById(string id)
        {
            return await GetByIdCompiled(_context,id);
        }

        public async Task<T> GetFirst()
        {
            return await GetFirstCompiled(_context);
        }

        public async Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression)
        {
            return await GetFirstByExpressionCompiled(_context, expression);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return Entity.Where(expression);
        }
    }
}

