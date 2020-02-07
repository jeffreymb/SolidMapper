using Microsoft.Extensions.DependencyInjection;
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

        private IMappingProfile<TSource, TDest> GetMappingProfile<TSource, TDest>()
        {
            var profile = _serviceProvider.GetRequiredService<IMappingProfile<TSource, TDest>>();
            profile.Mapper = this;
            return profile;
        }

        public Task<TDest> MapAsync<TSource, TDest>(TSource source, TDest dest)
        {
            var profile = GetMappingProfile<TSource, TDest>();

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TDest>> MapRangeAsync<TSource, TDest>(IEnumerable<TSource> source, IEnumerable<TDest> dest)
        {
            var profile = GetMappingProfile<TSource, TDest>();
            var destList = new List<TDest>();

            foreach (var item in source)
            {
                var mappedItem = await profile.MapAsync(item, profile.ItemConstructor());
                destList.Add(mappedItem);
            }

            dest = destList;
            return dest;
        }
    }
}
