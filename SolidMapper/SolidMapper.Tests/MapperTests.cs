using System.Threading.Tasks;
using Xunit;

namespace SolidMapper.Tests
{
    public sealed class MapperTests : Base
    {
        [Fact]
        public void MapsRange()
        {
            var source = new[] { 1, 2, 3 };
            var dest = GetMapper().MapRange<int, string>(source);

            Assert.Equal("1", dest[0]);
            Assert.Equal("2", dest[1]);
            Assert.Equal("3", dest[2]);
        }
    }
}
