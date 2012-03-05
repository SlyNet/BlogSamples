using System.Data.SqlClient;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using webapi.Infrastructure.Mappings;

namespace webapi.Infrastructure
{
    public static class NHibernateConfigurator
    {
        public static ISessionFactory BuildSessionFactory()
        {
            Configuration cfg = new Configuration();
            cfg.SessionFactory()
                .Integrate.Using<MsSql2008Dialect>()
                .Connected.Using(new SqlConnectionStringBuilder {
                        DataSource = @".\SQLEXPRESS",
                        InitialCatalog = "aspnet-webapi",
                        IntegratedSecurity = true
                    })
                .Schema.Updating();
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(ProductMap).Assembly.GetTypes()
                                                          .Where(t => t.Namespace != null && t.Namespace.StartsWith("webapi.Infrastructure.Mappings")));
            HbmMapping mappings = mapper.CompileMappingForAllExplicitlyAddedEntities();

            cfg.AddMapping(mappings);
            return cfg.BuildSessionFactory();
        }
    }
}