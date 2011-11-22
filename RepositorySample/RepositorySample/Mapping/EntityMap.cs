using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using RepositorySample.Domain;

namespace RepositorySample.Mapping
{
    public class EntityMap<T> : ClassMapping<T> where T : Entity
    {
        public EntityMap()
        {
            Id(x => x.Id);
        }
    }
}