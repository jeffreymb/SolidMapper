using SolidMapper.ConsoleApp.Models;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace SolidMapper.ConsoleApp.Profiles
{
    public sealed class HexToRGBProfile : IMappingProfile<HexColor, RGBColor>
    {
        public Func<HexColor, object> CacheKey => new Func<HexColor, object>(x => x.HexCode);
        public Func<RGBColor> ItemConstructor => new Func<RGBColor>(() => new RGBColor());

        public IMapper Mapper { get; set; }

        public Task<RGBColor> MapAsync(HexColor source, RGBColor dest)
        {
            var color = ColorTranslator.FromHtml(source.HexCode);
            dest.B = color.B;
            dest.G = color.G;
            dest.R = color.R;
            return Task.FromResult(dest);
        }
    }
}
