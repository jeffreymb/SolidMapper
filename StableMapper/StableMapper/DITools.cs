using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StableMapper
{
    public static class IServiceCollectionExtensions
    {
        public static void AddStableMapper(this IServiceCollection services, Assembly assembly)
        {
            AddStableMapper(services, new Assembly[] { assembly });
        }

        public static void AddStableMapper(this IServiceCollection services, Assembly[] assemblies)
        {
            var mappers = assemblies.SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Any(i => i.Namespace == "StableMapper"))).ToList();

            foreach (var mapper in mappers)
            {
                services.AddScoped(Type.GetType(mapper.AssemblyQualifiedName));
            }
        }
    }
}
