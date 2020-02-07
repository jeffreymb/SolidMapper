using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolidMapper
{
    public sealed class Mapper : IMapper
    {
        private readonly IDictionary<(Type SourceType, Type DestinationType, object Key), object> _cache;
        private readonly IServiceProvider _serviceProvider;

        public Mapper(IServiceProvider serviceProvider)
        {
            _cache = new Dictionary<(Type, Type, object), object>();
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

        public async Task<IList<TDest>> MapRangeAsync<TSource, TDest>(IEnumerable<TSource> source)
        {
            var profile = GetMappingProfile<TSource, TDest>();
            var destList = new List<TDest>();

            foreach (var item in source)
            {
                TDest mappedItem;
                var cacheKey = (typeof(TSource), typeof(TDest), profile.CacheKey(item));

                if (_cache.ContainsKey(cacheKey))
                {
                    mappedItem = (TDest)_cache[cacheKey];
                }

                else
                {
                    mappedItem = await profile.MapAsync(item, profile.ItemConstructor());
                    _cache[cacheKey] = mappedItem;
                }

                destList.Add(mappedItem);
            }

            return destList;
        }
    }
}
