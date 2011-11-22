using System.Collections.Generic;

namespace RepositorySample.Domain
{
    public class Category : Entity
    {
        public virtual string Name { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}