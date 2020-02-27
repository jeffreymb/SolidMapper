using AutoMapper;
using SolidMapper.ConsoleApp.Models;

namespace SolidMapper.ConsoleApp.Profiles
{
    public sealed class DataListToViewListAutoProfile : Profile
    {
        public DataListToViewListAutoProfile()
        {
            CreateMap<DataList, ViewList>()
                .ForPath(x => x.Items, x => x.MapFrom(p => p.Items))
                .ForPath(x => x.Name, p => p.MapFrom(p => p.Name));
        }
    }
}
