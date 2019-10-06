using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApiJwt.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _ctx;

        public GenericRepository(AppDbContext context)
        {
            _ctx = context;
        }


        public IQueryable<T> GetAll()
        {
            return _ctx.Set<T>();
        }


        public async Task<IQueryable<T>> GetAllAsync()
        {
            //First solution
            var result = _ctx.Set<T>().ToListAsync();
            return (await result).AsQueryable();

            //Second solution
            //IEnumerable<T> dbset = await _ctx.Set<T>().ToListAsync();
            //IQueryable<T> result = dbset.AsQueryable();
            //return result;
        }



        public async Task<IQueryable<T>> GetAllWithIncludeAsync(string relatedEntities)
        {
            //First solution
            var result = _ctx.Set<T>().Include(relatedEntities).ToListAsync();
            return (await result).AsQueryable();

            //Second solution
            //string[] includes = relatedEntities.Split(";");
            //var query = _ctx.Set<T>().AsQueryable();

            //foreach (string include in includes)
            //    query = query.Include(include);

            //return (await query.ToListAsync()).AsQueryable();
        }



        public IQueryable<T> GetBy(Expression<Func<T, bool>> keySelector)
        {
            IQueryable<T> result = _ctx.Set<T>().Where(keySelector);

            return result;
        }


        public T Insert(T entity)
        {
            _ctx.Set<T>().Add(entity);
            _ctx.SaveChanges();

            return entity;
        }


        public List<T> InsertRange(List<T> entities)
        {
            _ctx.Set<T>().AddRange(entities);
            _ctx.SaveChanges();

            return entities;
        }


        public T Update(T entity)
        {
            var entry = _ctx.Entry(entity);

            if (entry.State == EntityState.Detached)
                _ctx.Set<T>().Attach(entity);

            entry.State = EntityState.Modified;

            _ctx.SaveChanges();

            return entity;
        }



        public void Delete(T entity)
        {
            var entry = _ctx.Entry(entity);

            if (entry.State == EntityState.Detached)
                _ctx.Set<T>().Attach(entity);

            entry.State = EntityState.Deleted;

            _ctx.SaveChanges();
        }


        public void DeleteRange(List<T> entities)
        {
            _ctx.Set<T>().RemoveRange(entities);
            _ctx.SaveChanges();
        }
    }
}