using System.Collections.Generic;

namespace SolidMapper
{
    public interface IMapper
    {
        TDest Map<TSource, TDest>(TSource source, TDest dest, IMappingContext context = null);

        // Add a separate method for mapping multiple items, per Eric Lippert's comment on
        // https://stackoverflow.com/questions/8727523/generic-not-constraint-where-t-ienumerable
        IList<TDest> MapRange<TSource, TDest>(IEnumerable<TSource> source, IMappingContext context = null);
    }
}
