using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace SolidMapper
{
    public sealed class Mapper : IMapper
    {
        private readonly IDictionary<(Type SourceType, Type DestinationType, object Key), object> _cache;
        private readonly IMappingCondition[] _mappingConditions;
        private readonly IServiceProvider _serviceProvider;

        public Mapper(IMappingCondition[] mappingConditions,
                      IServiceProvider serviceProvider)
        {
            _cache = new Dictionary<(Type, Type, object), object>();
            _mappingConditions = mappingConditions ?? throw new ArgumentNullException(nameof(mappingConditions));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        private IMappingProfile<TSource, TDest> GetMappingProfile<TSource, TDest>()
        {
            var profile = _serviceProvider.GetRequiredService<IMappingProfile<TSource, TDest>>();
            return profile;
        }

        public TDest Map<TSource, TDest>(TSource source,
                                         TDest dest,
                                         IMappingContext context = null)
        {
            var profile = GetMappingProfile<TSource, TDest>();
            var cacheKey = (typeof(TSource), typeof(TDest), profile.CacheKey(source));

            if (!ShouldMap(source, context))
            {
                TryGetCached(cacheKey, out dest);
                return dest;
            }

            if (!TryGetCached(cacheKey, out dest))
            {
                context ??= new MappingContext(this);
                context.Tree.Push(source);
                dest = profile.Map(source, profile.ItemConstructor(), context);
                context.Tree.Pop();
                _cache[cacheKey] = dest;
            }

            return dest;
        }

        public IList<TDest> MapRange<TSource, TDest>(IEnumerable<TSource> source,
                                                     IMappingContext context = null)
        {
            var destList = new List<TDest>();

            if (source == null)
            {
                return destList;
            }

            TDest mappedItem;
            context ??= new MappingContext(this);
            var profile = GetMappingProfile<TSource, TDest>();

            foreach (var item in source)
            {
                var cacheKey = (typeof(TSource), typeof(TDest), profile.CacheKey(item));

                if (!ShouldMap(item, context))
                {
                    TryGetCached(cacheKey, out mappedItem);
                    continue;
                }

                if (!TryGetCached(cacheKey, out mappedItem))
                {
                    context.Tree.Push(item);
                    mappedItem = profile.Map(item, profile.ItemConstructor(), context);
                    context.Tree.Pop();
                    _cache[cacheKey] = mappedItem;
                }

                destList.Add(mappedItem);
            }

            return destList;
        }

        private bool ShouldMap<T>(T property,
                                  IMappingContext context)
        {
            foreach (var condition in _mappingConditions)
            {
                if (!condition.ShouldMap(property, context))
                {
                    return false;
                }
            }

            return true;
        }

        private bool TryGetCached<T>((Type, Type, object) cacheKey,
                                     out T value)
        {
            if (!_cache.ContainsKey(cacheKey))
            {
                value = default;
                return false;
            }

            value = (T)_cache[cacheKey];
            return true;
        }
    }
}
