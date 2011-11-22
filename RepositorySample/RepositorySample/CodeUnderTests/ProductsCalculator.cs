using System;
using System.Linq;
using RepositorySample.Domain;
using RepositorySample.Implementations;

namespace RepositorySample.CodeUnderTests
{
    public class ProductsCalculator
    {
        readonly IRepository<Product> products;

        public ProductsCalculator(IRepository<Product> products)
        {
            if (products == null) throw new ArgumentNullException("products");
            this.products = products;
        }

        public double GetTotalPrice()
        {
            var all = products.Fetch(x => x.Category).Where(x => x.Price > 5).ToList();
            return all.Sum(x => x.Price);
        }
    }
}