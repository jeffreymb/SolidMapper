using AutoMapper;
using SolidMapper.ConsoleApp.Models;

namespace SolidMapper.ConsoleApp.Profiles
{
    public sealed class DataListItemToViewListItemAutoProfile : Profile
    {
        public DataListItemToViewListItemAutoProfile()
        {
            CreateMap<DataListItem, ViewListItem>()
                .ForPath(x => x.List, x => x.MapFrom(p => p.List))
                .ForPath(x => x.Name, x => x.MapFrom(p => p.Name));
        }
    }
}
