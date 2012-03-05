using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using webapi.Models;

namespace webapi.Infrastructure.Mappings
{
    public class ProductMap : ClassMapping<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id, cfg => cfg.Generator(Generators.Native));

            Property(x => x.Name);
            Property(x => x.Price);
        }
    }
}