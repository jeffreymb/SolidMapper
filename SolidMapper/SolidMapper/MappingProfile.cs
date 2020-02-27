using System;

namespace SolidMapper
{
    public abstract class MappingProfile<TSource, TDest> : IMappingProfile<TSource, TDest>
    {
        public abstract Func<TSource, object> CacheKey { get; }
        public abstract Func<TDest> ItemConstructor { get; }

        public TDest Map(TSource source, TDest dest, IMappingContext context)
        {
            return dest;
        }
    }
}
