using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;
using RepositorySample.Domain;

namespace RepositorySample.Implementations.Nh
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

        public int Count
        {
            get
            {
                return this.session.Query<T>().Count();
            }
        }

        public Type ElementType
        {
            get
            {
                return this.session.Query<T>().ElementType;
            }
        }

        public Expression Expression
        {
            get
            {
                return this.session.Query<T>().Expression;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return this.session.Query<T>().Provider;
            }
        }

        public void Add(T item)
        {
            this.session.SaveOrUpdate(item);
        }

        public void Clear()
        {
            foreach (T entity in this)
            {
                this.session.Delete(entity);
            }
        }

        public bool Contains(T item)
        {
            return this.session.Get<T>(item.Id) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            if (Contains(item))
            {
                this.session.Delete(item);
                return true;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.session.Query<T>().GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.session.Query<T>().GetEnumerator();
        }

        public T Get(long id)
        {
            return this.session.Get<T>(id);
        }
    }
}