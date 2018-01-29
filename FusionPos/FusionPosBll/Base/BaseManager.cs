using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FuasionPoRepository.Base;

namespace FusionPosBll.Base
{
    public class BaseManager<T> where T:class
    {
        protected BaseRepository<T> _Repository;

        public BaseManager(BaseRepository<T> repository )
        {
            _Repository = repository;
        }

        public virtual bool Add(T entity)
        {
            return _Repository.Add(entity);
        }
        public virtual bool Upate(T entity)
        {
            return _Repository.Add(entity);
        }

        public virtual bool Remove(T entity)
        {
            return _Repository.Remove(entity);
        }

        public ICollection<T> GetAll()
        {
            return _Repository.GetAll();
        }

        public virtual ICollection<T> Get(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includes)
        {
            return _Repository.Get(predicate, includes);
        }
    }
}
