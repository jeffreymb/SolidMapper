using System;
using System.Collections.Generic;

namespace SolidMapper.Abstractions.Tests
{
    public sealed class MockMapper : IMapper
    {
        public TDest Map<TSource, TDest>(TSource source,
                                         TDest dest,
                                         IMappingTree tree = null)
        {
            throw new NotImplementedException();
        }

        public IList<TDest> MapRange<TSource, TDest>(IEnumerable<TSource> source,
                                                     IMappingTree tree = null)
        {
            return new List<TDest>() as IList<TDest>;
        }
    }
}
