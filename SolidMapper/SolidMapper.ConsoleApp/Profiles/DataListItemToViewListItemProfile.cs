using SolidMapper.ConsoleApp.Models;
using System;

namespace SolidMapper.ConsoleApp.Profiles
{
    public sealed class DataListItemToViewListItemProfile : IMappingProfile<DataListItem, ViewListItem>
    {
        public Func<DataListItem, object> CacheKey => new Func<DataListItem, object>(x => x.Name);

        public Func<ViewListItem> ItemConstructor => new Func<ViewListItem>(() => new ViewListItem());

        public ViewListItem Map(DataListItem source,
                                ViewListItem dest,
                                IMappingContext context)
        {
            dest.Name = source.Name;
            dest.List = context.Mapper.Map(source.List, dest.List, context);

            return dest;
        }
    }
}
