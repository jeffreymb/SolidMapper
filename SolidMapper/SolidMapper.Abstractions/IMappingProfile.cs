using System;
using System.Threading.Tasks;

namespace SolidMapper
{
    public interface IMappingProfile<TSource, TDest>
    {
        Func<TDest> ItemConstructor { get; }
        IMapper Mapper { get; set; }

        Task<TDest> MapAsync(TSource source, TDest dest);
    }
}
