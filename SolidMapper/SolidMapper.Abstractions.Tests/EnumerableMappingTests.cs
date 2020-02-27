using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SolidMapper.Abstractions.Tests
{
    public sealed class EnumerableMappingTests
    {
        private MockMapper Mapper => new MockMapper();

        [Fact]
        public void CanCallWithArrayTypes()
        {
            var source = new int[0];
            Mapper.MapRange<int, string>(source);
        }

        [Fact]
        public void CanCallWithEnumerableTypes()
        {
            IEnumerable<int> source = new List<int>();
            Mapper.MapRange<int, string>(source);

            var orderedSource = new List<int>().OrderBy(x => x);
            Mapper.MapRange<int, string>(source);
        }

        [Fact]
        public void CanCallWithListTypes()
        {
            Mapper.MapRange<int, string>(new List<int>());

            IList<int> source = new List<int>();
            Mapper.MapRange<int, string>(source);
        }
    }
}
