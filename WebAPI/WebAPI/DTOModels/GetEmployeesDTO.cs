using AutoMapper;
using HealthyHole.Application;
using HealthyHole.Application.Interfaces;
using HealthyHole.Application.Queries;
using Constants = HealthyHole.Domain.Constants;

namespace HealthyHole.WebAPI.DTOModels
{
    public class GetEmployeesDto : IMapWith<GetEmployeesDto>
    {
        public Constants.Positions Position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetEmployeesDto, GetEmployeesQuery>().ForMember(
                employeeDto => employeeDto.Positions,
                opt => opt.MapFrom(employee => employee.Position));
        }
    }
}