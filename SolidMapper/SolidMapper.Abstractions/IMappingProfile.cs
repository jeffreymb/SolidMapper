using System;

namespace SolidMapper
{
    public interface IMappingProfile<TSource, TDest>
    {
        Func<TSource, object> CacheKey { get; }
        Func<TDest> ItemConstructor { get; }

        TDest Map(TSource source, TDest dest, IMappingContext context);
    }
}
