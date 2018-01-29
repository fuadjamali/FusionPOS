using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FuasionPoRepository.DatabaseContexts;

namespace FuasionPoRepository.Base
{
    public class BaseRepository<T> where T:class 
    {
        protected DbContext _db;

        public DbSet<T> Table
        {
            get
            {
                return _db.Set<T>();
                
            }
        }

        public BaseRepository(DbContext db)
        {
            _db = db;
        }

        public bool Add(T entity)
        {
            Table.Add(entity);
            return _db.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            Table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            return _db.SaveChanges() > 0;
        }

        public bool Remove(T entity)
        {
            Table.Remove(entity);
            return _db.SaveChanges() > 0;
        }

        public ICollection<T> GetAll()
        {
            return Table.ToList();
        }

        public ICollection<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).ToList();
        }

        public ICollection<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            if (includes == null || !includes.Any())
            {
                return Get(predicate);
            }

            DisableLazyLoading();
            var result = includes
               .Aggregate(
                   Table.AsQueryable(),
                   (current, include) => current.Include(include),
                  c => c.Where(predicate)
               ).ToList();
            EnableLazyLoading();
            return result.ToList();
        }
        private void EnableLazyLoading()
        {
            _db.Configuration.LazyLoadingEnabled = true;
        }

        private void DisableLazyLoading()
        {
            _db.Configuration.LazyLoadingEnabled = false;
        }
    }
}
