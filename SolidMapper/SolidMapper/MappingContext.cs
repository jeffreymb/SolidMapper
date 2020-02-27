using System;
using System.Collections;

namespace SolidMapper
{
    public sealed class MappingContext : IMappingContext
    {
        public IMapper Mapper { get; }

        public Stack Tree { get; }

        public MappingContext(IMapper mapper)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            Tree = new Stack();
        }
    }
}
