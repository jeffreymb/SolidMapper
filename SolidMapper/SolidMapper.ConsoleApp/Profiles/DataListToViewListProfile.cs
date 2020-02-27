using SolidMapper.ConsoleApp.Models;
using System;

namespace SolidMapper.ConsoleApp.Profiles
{
    public sealed class DataListToViewListProfile : IMappingProfile<DataList, ViewList>
    {
        public Func<DataList, object> CacheKey => new Func<DataList, object>(x => x.Id);

        public Func<ViewList> ItemConstructor => new Func<ViewList>(() => new ViewList());

        public ViewList Map(DataList source,
                            ViewList dest,
                            IMappingContext context)
        {
            dest.Name = source.Name;
            dest.Items = context.Mapper.MapRange<DataListItem, ViewListItem>(source.Items, context);

            return dest;
        }
    }
}
