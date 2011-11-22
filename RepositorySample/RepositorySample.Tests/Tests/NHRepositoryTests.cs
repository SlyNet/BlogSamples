using System;
using System.Data.SQLite;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using RepositorySample.CodeUnderTests;
using RepositorySample.Domain;
using RepositorySample.Implementations;
using RepositorySample.Mapping;

namespace RepositorySample.Tests.Tests
{
    [TestFixture]
    public class NHRepositoryTests
    {
        [Test]
        public void Should_work_with_nhibernate()
        {
            Configuration configuration = new Configuration();
            configuration.SessionFactory()
                .Integrate.Using<SQLiteDialect>()
                .Connected.Using(new SQLiteConnectionStringBuilder{DataSource = ":memory:", Version = 3}).LogSqlInConsole();
            configuration.AddDeserializedMapping(DomainMapper.GetMappings(), "domain");

            using(var factory = configuration.BuildSessionFactory())
            {
                using(var session = factory.OpenSession())
                {
                    new SchemaExport(configuration).Execute(true, true, false, session.Connection, Console.Out);
                    ProductsCalculator productsCalculator = new ProductsCalculator(new Repository<Product>(session));
                    var price = productsCalculator.GetTotalPrice();

                    Assert.That(price, Is.EqualTo(0));
                }
            }
        }
    }
}