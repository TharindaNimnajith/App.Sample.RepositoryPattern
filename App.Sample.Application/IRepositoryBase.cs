using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Sample.Application
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> FindAllAsync();

        Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);

        Task<T> FindSingleAsync(Expression<Func<T, bool>> expression);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}