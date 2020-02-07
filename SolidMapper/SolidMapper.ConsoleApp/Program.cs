using Microsoft.Extensions.DependencyInjection;
using SolidMapper.ConsoleApp.Models;
using SolidMapper.ConsoleApp.Profiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SolidMapper.ConsoleApp
{
    public sealed class Program
    {
        private static Mapper GetMapper()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IMappingProfile<HexColor, RGBColor>, HexToRGBProfile>()
                .BuildServiceProvider();
            return new Mapper(serviceProvider);
        }

        public static async Task Main(string[] args)
        {
            TestAutoMapper();
            await TestSolidMapper();
            Console.ReadKey();
        }

        private static void TestAutoMapper()
        {
            var indices = Enumerable.Range(0, 1_000_000).ToArray();
            var colors = new[] { "#003f84", "#009ca7", "#6e3075", "#d54122", "#648c2e" };
            var source = new List<HexColor>();

            for (var i = 0; i < indices.Length; i++)
            {
                var index = indices[i] % 5;
                var color = colors[index];
                var hexColor = new HexColor { HexCode = color };
                source.Add(hexColor);
            }

            var mapperConfig = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new HexToRGBAutoProfile());
            });
            var mapper = mapperConfig.CreateMapper();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var dest = mapper.Map(source, new List<RGBColor>());

            stopwatch.Stop();
            Console.WriteLine($"Auto-mapped {dest.Count} objects in {stopwatch.Elapsed}.");
        }

        private static async Task TestSolidMapper()
        {
            var mapper = GetMapper();
            var indices = Enumerable.Range(0, 1_000_000).ToArray();
            var colors = new[] { "#003f84", "#009ca7", "#6e3075", "#d54122", "#648c2e" };
            var source = new List<HexColor>();

            for (var i = 0; i < indices.Length; i++)
            {
                var index = indices[i] % 5;
                var color = colors[index];
                var hexColor = new HexColor { HexCode = color };
                source.Add(hexColor);
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var dest = await mapper.MapRangeAsync<HexColor, RGBColor>(source);

            stopwatch.Stop();
            Console.WriteLine($"Solid-mapped {dest.Count} objects in {stopwatch.Elapsed}.");
        }
    }
}
