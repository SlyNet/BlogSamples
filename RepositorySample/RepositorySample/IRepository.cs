using System.Collections.Generic;
using System.Linq;
using RepositorySample.Domain;

namespace RepositorySample
{
    public interface IRepository<T> : ICollection<T>, IQueryable<T>
        where T: Entity
    {
        T Get(long id);
    }
}