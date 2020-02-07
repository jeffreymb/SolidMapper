using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolidMapper.Abstractions.Tests
{
    public sealed class MockMapper : IMapper
    {
        public Task<TDest> MapAsync<TSource, TDest>(TSource source,
                                                    TDest dest)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TDest>> MapRangeAsync<TSource, TDest>(IEnumerable<TSource> source)
        {
            return Task.FromResult(new List<TDest>() as IList<TDest>);
        }
    }
}
