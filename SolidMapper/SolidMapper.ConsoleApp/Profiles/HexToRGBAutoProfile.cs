using AutoMapper;
using SolidMapper.ConsoleApp.Models;
using System.Drawing;

namespace SolidMapper.ConsoleApp.Profiles
{
    public sealed class HexToRGBAutoProfile : Profile
    {
        public HexToRGBAutoProfile()
        {
            CreateMap<HexColor, RGBColor>()
                .ForPath(x => x.B, x => x.MapFrom(p => ColorTranslator.FromHtml(p.HexCode).B))
                .ForPath(x => x.G, x => x.MapFrom(p => ColorTranslator.FromHtml(p.HexCode).G))
                .ForPath(x => x.R, x => x.MapFrom(p => ColorTranslator.FromHtml(p.HexCode).R));
        }
    }
}
