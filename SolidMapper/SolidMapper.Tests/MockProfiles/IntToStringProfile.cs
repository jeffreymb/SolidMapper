using System;
using System.Threading.Tasks;

namespace SolidMapper.Tests.MockProfiles
{
    public sealed class IntToStringProfile : IMappingProfile<int, string>
    {
        public Func<string> ItemConstructor => new Func<string>(() => string.Empty);
        public IMapper Mapper { get; set; }

        public Task<string> MapAsync(int source, string dest)
        {
            return Task.FromResult(source.ToString());
        }
    }
}
