using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RepositorySample.Domain;

namespace RepositorySample.Tests
{
    public class FakeRepository<T> : List<T>, IRepository<T>
        where T : Entity
    {
        public FakeRepository(IEnumerable<T> products) : base(products)
        {
        }

        public FakeRepository()
        {
        }

        public T Get(long id)
        {
            return this.FirstOrDefault(x => x.Id == id);
        }

        public Expression Expression
        {
            get { return ((IEnumerable<T>)this).Select(x => x).AsQueryable().Expression; }
        }

        public Type ElementType
        {
            get { return ((IEnumerable<T>)this).Select(x => x).AsQueryable().ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return ((IEnumerable<T>)this).Select(x => x).AsQueryable().Provider; }
        }
    }
}