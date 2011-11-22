using RepositorySample.Domain;

namespace RepositorySample.Mapping
{
    public sealed class CategoryMap : EntityMap<Category>
    {
        public CategoryMap()
        {
            Property(x => x.Name);
            Bag(x => x.Products, map => {
                    map.Key(km => km.Column("CategoryId"));
                }, action => action.OneToMany());
        }
    }
}