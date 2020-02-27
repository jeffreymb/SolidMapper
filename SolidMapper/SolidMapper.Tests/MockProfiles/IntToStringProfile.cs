using System;
using System.Threading.Tasks;

namespace SolidMapper.Tests.MockProfiles
{
    public sealed class IntToStringProfile : IMappingProfile<int, string>
    {
        public Func<int, object> CacheKey => new Func<int, object>(x => x);
        public Func<string> ItemConstructor => new Func<string>(() => string.Empty);

        public string Map(int source,
                          string dest,
                          IMapper mapper,
                          IMappingTree tree)
        {
            return source.ToString();
        }
    }
}
