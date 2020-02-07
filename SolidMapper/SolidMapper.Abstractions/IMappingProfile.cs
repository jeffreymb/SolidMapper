using System.Threading.Tasks;

namespace SolidMapper.Abstractions
{
    public interface IMappingProfile<TSource, TDest>
    {
        IMapper Mapper { get; set; }

        Task<TDest> MapAsync(TSource source, TDest dest);
    }
}
