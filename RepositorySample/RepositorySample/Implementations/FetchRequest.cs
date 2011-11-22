using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Linq;

namespace RepositorySample.Implementations
{
    public class FetchRequest<TQueried, TFetch> : IFetchRequest<TQueried, TFetch>
    {
        public IEnumerator<TQueried> GetEnumerator()
        {
            return NhFetchRequest.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return NhFetchRequest.GetEnumerator();
        }

        public Type ElementType
        {
            get
            {
                return NhFetchRequest.ElementType;
            }
        }

        public Expression Expression
        {
            get
            {
                return NhFetchRequest.Expression;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return NhFetchRequest.Provider;
            }
        }

        public FetchRequest(INhFetchRequest<TQueried, TFetch> nhFetchRequest)
        {
            NhFetchRequest = nhFetchRequest;
        }

        public INhFetchRequest<TQueried, TFetch> NhFetchRequest { get; private set; }
    }
}