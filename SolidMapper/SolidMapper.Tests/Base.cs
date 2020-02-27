using Microsoft.Extensions.DependencyInjection;
using SolidMapper.Tests.MockProfiles;

namespace SolidMapper.Tests
{
    public abstract class Base
    {
        protected static Mapper GetMapper()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IMappingProfile<int, string>, IntToStringProfile>()
                .BuildServiceProvider();
            return new Mapper(serviceProvider);
        }

    }
}
