using NHibernate;
using RepositorySample.Domain;

namespace RepositorySample.Mapping
{
    public sealed class ProductMap : EntityMap<Product>
    {
        public ProductMap()
        {
            Property(x => x.Name);
            Property(x => x.Price, pm => pm.Type(NHibernateUtil.Double));
            ManyToOne(x => x.Category, mto => mto.Column("CategoryId"));
        }
    }
}