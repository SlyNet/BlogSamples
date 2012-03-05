using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using NHibernate;
using NHibernate.Linq;
using webapi.Infrastructure;
using webapi.Models;

namespace webapi.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly ISession nhSession;

        public ProductsController(ISession nhSession)
        {
            if (nhSession == null) throw new ArgumentNullException("nhSession");
            this.nhSession = nhSession;
        }

        [Transaction]
        public IQueryable<Product> Get()
        {
            return nhSession.Query<Product>();
        }
    }
}
