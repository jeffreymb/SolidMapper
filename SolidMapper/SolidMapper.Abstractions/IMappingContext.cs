using System.Collections;

namespace SolidMapper
{
    public interface IMappingContext
    {
        IMapper Mapper { get; }
        Stack Tree { get; }
    }
}
