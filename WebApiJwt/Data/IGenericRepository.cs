using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApiJwt.Data
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllWithIncludeAsync(string relatedEntities);

        IQueryable<T> GetBy(Expression<Func<T, bool>> keySelector);

        T Insert(T entity);
        List<T> InsertRange(List<T> entities);

        T Update(T entity);

        void Delete(T entity);
        void DeleteRange(List<T> entities);
    }
}