using App.Sample.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Sample.Infrastructure.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public RepositoryContext RepositoryContext { get; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public async Task CreateAsync(T entity)
        {
            await RepositoryContext.Set<T>().AddAsync(entity);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await RepositoryContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await RepositoryContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            RepositoryContext.Entry(entity).State = EntityState.Modified;
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> expression)
        {
            return await RepositoryContext.Set<T>().FirstOrDefaultAsync();
        }
    }
}