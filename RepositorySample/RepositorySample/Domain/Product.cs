namespace RepositorySample.Domain
{
    public class Product : Entity
    {
        public virtual string Name { get; set; }

        public virtual Category Category { get; set; }

        public virtual double Price { get; set; }

        public virtual Price FullPrice { get; set; }
    }
}