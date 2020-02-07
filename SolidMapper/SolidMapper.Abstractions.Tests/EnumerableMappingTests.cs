using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SolidMapper.Abstractions.Tests
{
    public sealed class EnumerableMappingTests
    {
        private MockMapper Mapper => new MockMapper();

        [Fact]
        public void CanCallWithEnumerableTypes()
        {
            IEnumerable<int> source = new List<int>();
            IEnumerable<string> dest = new List<string>();
            Mapper.MapRangeAsync(source, dest);

            var orderedSource = new List<int>().OrderBy(x => x);
            var orderedDest = new List<string>().OrderBy(x => x);
            Mapper.MapRangeAsync(source, dest);
        }

        [Fact]
        public void CanCallWithListTypes()
        {
            Mapper.MapRangeAsync(new List<int>(), new List<string>());

            IList<int> source = new List<int>();
            IList<string> dest = new List<string>();
            Mapper.MapRangeAsync(source, dest);
        }
    }
}
