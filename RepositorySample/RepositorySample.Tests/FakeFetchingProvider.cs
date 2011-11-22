using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RepositorySample.Implementations;

namespace RepositorySample.Tests
{
    public class FakeFetchingProvider : IFetchingProvider
    {
        public IFetchRequest<TOriginating, TRelated> Fetch<TOriginating, TRelated>(IQueryable<TOriginating> query,
            Expression<Func<TOriginating, TRelated>> relatedObjectSelector)
        {
            return new FetchRequest<TOriginating, TRelated>(query);
        }

        public IFetchRequest<TOriginating, TRelated> FetchMany<TOriginating, TRelated>(IQueryable<TOriginating> query,
            Expression<Func<TOriginating, IEnumerable<TRelated>>> relatedObjectSelector)
        {
            return new FetchRequest<TOriginating, TRelated>(query);
        }

        public IFetchRequest<TQueried, TRelated> ThenFetch<TQueried, TFetch, TRelated>(IFetchRequest<TQueried, TFetch> query,
            Expression<Func<TFetch, TRelated>> relatedObjectSelector)
        {
            var impl = query as FetchRequest<TQueried, TFetch>;
            return new FetchRequest<TQueried, TRelated>(impl.query);
        }

        public IFetchRequest<TQueried, TRelated> ThenFetchMany<TQueried, TFetch, TRelated>(IFetchRequest<TQueried, TFetch> query,
            Expression<Func<TFetch, IEnumerable<TRelated>>> relatedObjectSelector)
        {
            var impl = query as FetchRequest<TQueried, TFetch>;
            return new FetchRequest<TQueried, TRelated>(impl.query);
        }

        public class FetchRequest<TQueried, TFetch> : IFetchRequest<TQueried, TFetch>
        {
            public readonly IQueryable<TQueried> query;

            public IEnumerator<TQueried> GetEnumerator()
            {
                return query.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return query.GetEnumerator();
            }

            public Type ElementType
            {
                get { return query.ElementType; }
            }

            public Expression Expression
            {
                get { return query.Expression; }
            }

            public IQueryProvider Provider
            {
                get { return query.Provider; }
            }

            public FetchRequest(IQueryable<TQueried> query)
            {
                this.query = query;
            }
        }
    }
}