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

        public Task<IEnumerable<TDest>> MapRangeAsync<TSource, TDest>(IEnumerable<TSource> source,
                                                                      IEnumerable<TDest> dest)
        {
            return Task.FromResult(new List<TDest>() as IEnumerable<TDest>);
        }
    }
}
