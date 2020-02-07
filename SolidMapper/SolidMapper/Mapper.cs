using Microsoft.Extensions.DependencyInjection;
using SolidMapper.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolidMapper
{
    public sealed class Mapper : IMapper
    {
        private readonly IServiceProvider _serviceProvider;

        public Mapper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public Task<TDest> MapAsync<TSource, TDest>(TSource source, TDest dest)
        {
            var profile = _serviceProvider.GetRequiredService<IMappingProfile<TSource, TDest>>();
            profile.Mapper = this;

            throw new NotImplementedException();
        }

        public Task<IEnumerable<TDest>> MapRangeAsync<TSource, TDest>(IEnumerable<TSource> source, IEnumerable<TDest> dest)
        {
            throw new NotImplementedException();
        }
    }
}
