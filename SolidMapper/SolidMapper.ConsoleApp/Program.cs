using Microsoft.Extensions.DependencyInjection;
using SolidMapper.Conditions;
using SolidMapper.ConsoleApp.Models;
using SolidMapper.ConsoleApp.Profiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SolidMapper.ConsoleApp
{
    public sealed class Program
    {
        private static Mapper GetMapper()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IMappingProfile<HexColor, RGBColor>, HexToRGBProfile>()
                .AddScoped<IMappingProfile<DataList, ViewList>, DataListToViewListProfile>()
                .AddScoped<IMappingProfile<DataListItem, ViewListItem>, DataListItemToViewListItemProfile>()
                .BuildServiceProvider();
            return new Mapper(new IMappingCondition[] { new RecursionCondition() }, serviceProvider);
        }

        public static void Main(string[] args)
        {
            //TestAutoMapper();
            //TestSolidMapper();    // Faster AND uses a lot less memory! 🎉

            var source = new List<DataList>();

            for (var i = 0; i < 100_000; i++)
            {
                var list = new DataList
                {
                    Id = Guid.NewGuid(),
                    Items = new List<DataListItem>(),
                    Name = "Groceries"
                };

                for (var j = 0; j < 500; j++)
                {
                    var item = new DataListItem
                    {
                        List = list,
                        Name = "Milk"
                    };
                    list.Items.Add(item);
                }

                source.Add(list);
            }

            TestAutoMapperLists(source);
            TestSolidMapperLists(source);

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

        private static void TestSolidMapper()
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

            var dest = mapper.MapRange<HexColor, RGBColor>(source);

            stopwatch.Stop();
            Console.WriteLine($"Solid-mapped {dest.Count} objects in {stopwatch.Elapsed}.");
        }

        private static void TestAutoMapperLists(IList<DataList> source)
        {
            var mapperConfig = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DataListToViewListAutoProfile());
                cfg.AddProfile(new DataListItemToViewListItemAutoProfile());
            });
            var mapper = mapperConfig.CreateMapper();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var dest = mapper.Map(source, new List<DataList>());

            stopwatch.Stop();
            Console.WriteLine($"Auto-mapped {dest.Count} objects in {stopwatch.Elapsed}.");
        }

        private static void TestSolidMapperLists(IList<DataList> source)
        {
            var mapper = GetMapper();
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var dest = mapper.MapRange<DataList, ViewList>(source);

            stopwatch.Stop();
            Console.WriteLine($"Solid-mapped {dest.Count} objects in {stopwatch.Elapsed}.");
        }
    }
}
