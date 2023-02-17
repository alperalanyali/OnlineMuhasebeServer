﻿using System;
using Domain.Abstractions;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq.Expressions;
namespace Persistence.Repositories.GenericRepositories.CompanyDbContext
{
    public class CompanyDbQueryRepository<T> : ICompanyDbQueryRepository<T> where T : Entity
    {
        private Context.CompanyDbContext _context;

        private static readonly Func<Context.CompanyDbContext, string, Task<T>> GetByIdCompiled =
           EF.CompileAsyncQuery((Context.CompanyDbContext context, string id) =>
               context.Set<T>().AsNoTracking().FirstOrDefault(p => p.Id == id));

        private static readonly Func<Context.CompanyDbContext, Task<T>> GetFirstCompiled =
            EF.CompileAsyncQuery((Context.CompanyDbContext context) =>
                context.Set<T>().AsNoTracking().FirstOrDefault()
            );



        public DbSet<T> Entity { get ; set; }

        public void SetDbContextInst(DbContext context)
        {
            _context = (Context.CompanyDbContext)context;

            Entity = _context.Set<T>();
        }

        public IQueryable<T> GetAll( bool isTracking = true)
        {
            var result = Entity.AsQueryable();
            if (!isTracking)
                result = result.AsNoTracking();
            return result;
        }

        public async Task<T> GetById(string id, bool isTracking = true)
        {
            return await GetByIdCompiled(_context,id);
        }

        public async Task<T> GetFirst( bool isTracking = true)
        {
            return await GetFirstCompiled(_context);
        }

        public async Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression, bool isTracking = true)
        {
            T entity = null;
            if (!isTracking)
                entity = await Entity.AsNoTracking().Where(expression).FirstOrDefaultAsync();
            else
                entity = await Entity.Where(expression).FirstOrDefaultAsync();
            return entity;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true)
        {
            var result = Entity.Where(expression);
            if (!isTracking)
                result = result.AsNoTracking();
            return result;
        }
    }
}

