using System.Collections.Generic;

namespace RepositorySample.Domain
{
    public class Category
    {
        public virtual string Name { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}