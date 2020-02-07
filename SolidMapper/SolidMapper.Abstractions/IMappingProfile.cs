using System;
using System.Threading.Tasks;

namespace SolidMapper
{
    public interface IMappingProfile<TSource, TDest>
    {
        Func<TSource, object> CacheKey { get; }
        Func<TDest> ItemConstructor { get; }
        IMapper Mapper { get; set; }

        Task<TDest> MapAsync(TSource source, TDest dest);
    }
}
