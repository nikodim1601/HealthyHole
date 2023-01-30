using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using HealthyHole.Application.Interfaces;

namespace HealthyHole.Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(Assembly assembly) => ApplyMappingsFromAssembly(assembly);


        /// <summary>
        /// Проверяет сборку, ищет типы, реализующие <see cref="IMapWith{T}" /> и применяет маппинг./>.
        /// </summary>
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>))).ToList();


            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}