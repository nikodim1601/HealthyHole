using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(Assembly assembly) => ApplyMappingsFromAssebly(assembly);


        /// <summary>
        /// Проверяет сборку, ищет типы, реализующие <see cref="IMapWith{T}" /> и применяет маппинг./>.
        /// </summary>
        private void ApplyMappingsFromAssebly(Assembly assembly)
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