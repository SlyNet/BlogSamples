using System.Collections.Generic;
using NUnit.Framework;
using RepositorySample.CodeUnderTests;
using RepositorySample.Domain;
using System.Linq;
using RepositorySample.Implementations.Nh;

namespace RepositorySample.Tests.Tests
{
    [TestFixture]
    public class FakeRepositoryTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            EagerFetch.FetchingProvider = () => new FakeFetchingProvider();
        }

        [Test]
        public void Repository_can_be_created_from_simple_list()
        {
            Product product = new Product();

            List<Product> products = new List<Product> { product };

            IRepository<Product> repository = new FakeRepository<Product>(products);
            repository.Fetch(x => x.Category);

            Assert.That(repository.ToList(), Is.Not.Empty);
        }

        [Test]
        public void Fetching_provider_should_be_mockable()
        {
            Product product = new Product { Price = 10 };
            IRepository<Product> products = new FakeRepository<Product> { product };

            ProductsCalculator calculator = new ProductsCalculator(products);

            double totalPrice = calculator.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(10));
        }

        [Test]
        public void Fetching_Of_nested_sets_Should_work()
        {
            IRepository<Category> categories = new FakeRepository<Category>();
            categories.Where(x => x.Name == "test")
                .FetchMany(x => x.Products).ThenFetch(x => x.FullPrice);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            EagerFetch.FetchingProvider = () => new NhFetchingProvider();
        }
    }
}