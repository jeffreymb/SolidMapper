using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidMapper.Abstractions
{
    public interface IMapper
    {
        Task<TDest> MapAsync<TSource, TDest>(TSource source, TDest dest);
        Task<TDest> MapAsync<TBaseSource, TBaseDest, TDest>(TBaseSource source, TBaseDest dest);
        Task<IList<TDest>> MapAsync<TSource, TDest>(IEnumerable<TSource> source, IList<TDest> dest);
        Task<IList<TDest>> MapAsync<TSource, TDest>(IList<TSource> source, IList<TDest> dest);
        Task<IList<TDest>> MapAsync<TSource, TDest>(IEnumerable<TSource> source, List<TDest> dest);
        Task<IList<TDest>> MapAsync<TSource, TDest>(IList<TSource> source, List<TDest> dest);
        Task<IList<TDest>> MapAsync<TSource, TDest>(TSource[] source, List<TDest> dest);
        Task<IList<TDest>> MapAsync<TSource, TDest>(TSource[] source, IList<TDest> dest);
        Task<IList<TDest>> MapAsync<TSource, TDest>(IOrderedEnumerable<TSource> source, IList<TDest> dest);
        Task<IList<TDest>> MapAsync<TSource, TDest>(IOrderedEnumerable<TSource> source, List<TDest> dest);
        Task<IList<TDest>> MapAsync<TSource, TDest>(List<TSource> source, IList<TDest> dest);
    }
}
