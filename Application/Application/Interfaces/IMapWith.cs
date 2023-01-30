using AutoMapper;

namespace HealthyHole.Application.Interfaces
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