using System;
using System.Reflection;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;

namespace RepositorySample.Mapping
{
    public class DomainMapper
    {
        public static HbmMapping GetMappings()
        {
            var mapper = new ModelMapper();
            Type[] exportedTypes = Assembly.GetExecutingAssembly().GetExportedTypes();
            mapper.AddMappings(exportedTypes);
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            return domainMapping;
        } 
    }
}