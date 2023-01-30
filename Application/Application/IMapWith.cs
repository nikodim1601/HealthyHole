using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IMapWith<T>
    {
        /// <summary>
        /// Создает конфигурацию из исходного типа. 
        /// </summary>
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType()); // Сорри за реализацию интерфейса, если вы так не делаете...
    }
}