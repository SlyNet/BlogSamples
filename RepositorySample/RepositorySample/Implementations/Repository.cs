using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;
using RepositorySample.Domain;

namespace RepositorySample.Implementations
{
    public class Repository<T> : IRepository<T>
        where T : Entity
    {
        readonly ISession session;

        public Repository(ISession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException("session");
            }

            this.session = session;
        }

        public T Get(long id)
        {
            return this.session.Get<T>(id);
        }

        #region ICollection

        public IEnumerator<T> GetEnumerator()
        {
            return session.Query<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return session.Query<T>().GetEnumerator();
        }

        public void Add(T item)
        {
            session.SaveOrUpdate(item);
        }

        public void Clear()
        {
            foreach (T entity in this)
            {
                session.Delete(entity);
            }
        }

        public bool Contains(T item)
        {
            return session.Get<T>(item.Id) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            if (this.Contains(item))
            {
                this.session.Delete(item);
                return true;
            }

            return false;
        }

        public int Count
        {
            get
            {
                return session.Query<T>().Count();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        #endregion ICollection

        #region IQuerable

        public Expression Expression
        {
            get
            {
                return session.Query<T>().Expression;
            }
        }

        public Type ElementType
        {
            get
            {
                return session.Query<T>().ElementType;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return session.Query<T>().Provider;
            }
        }

        #endregion
    }
}