using SolidMapper.ConsoleApp.Models;
using System;
using System.Drawing;

namespace SolidMapper.ConsoleApp.Profiles
{
    public sealed class HexToRGBProfile : IMappingProfile<HexColor, RGBColor>
    {
        public Func<HexColor, object> CacheKey => new Func<HexColor, object>(x => x.HexCode);
        public Func<RGBColor> ItemConstructor => new Func<RGBColor>(() => new RGBColor());

        public RGBColor Map(HexColor source,
                            RGBColor dest,
                            IMappingContext context)
        {
            var color = ColorTranslator.FromHtml(source.HexCode);
            dest.B = color.B;
            dest.G = color.G;
            dest.R = color.R;
            return dest;
        }
    }
}
