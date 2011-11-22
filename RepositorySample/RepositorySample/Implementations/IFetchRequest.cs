using System.Linq;

namespace RepositorySample.Implementations
{
    public interface IFetchRequest<TQueried, TFetch> : IOrderedQueryable<TQueried>
    {
    }
}