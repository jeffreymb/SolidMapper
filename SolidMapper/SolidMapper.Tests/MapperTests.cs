using Microsoft.Extensions.DependencyInjection;
using SolidMapper.Tests.MockProfiles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SolidMapper.Tests
{
    public sealed class MapperTests
    {
        private static Mapper GetMapper()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IMappingProfile<int, string>, IntToStringProfile>()
                .BuildServiceProvider();
            return new Mapper(serviceProvider);
        }

        [Fact]
        public async Task MapsRange()
        {
            var source = new[] { 1, 2, 3 };
            var dest = new List<string>();
            dest = (await GetMapper().MapRangeAsync(source, dest)).ToList();

            Assert.Equal("1", dest[0]);
            Assert.Equal("2", dest[1]);
            Assert.Equal("3", dest[2]);
        }
    }
}
