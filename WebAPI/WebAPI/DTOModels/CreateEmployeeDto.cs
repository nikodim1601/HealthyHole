using AutoMapper;
using HealthyHole.Application;
using HealthyHole.Application.Commands.EmployeeCommands;
using HealthyHole.Application.Interfaces;
using Constants = HealthyHole.Domain.Constants;

namespace HealthyHole.WebAPI.DTOModels
{
    public class CreateEmployeeDto : IMapWith<CreateEmployeeDto>
    {
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public Constants.Positions? Position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmployeeDto, CreateEmployeeCommand>().ForMember(
                    employeeDto => employeeDto.SecondName,
                    opt => opt.MapFrom(employee => employee.SecondName))
                .ForMember(employeeDto => employeeDto.FirstName, opt => opt.MapFrom(employee => employee.FirstName))
                .ForMember(employeeDto => employeeDto.SureName, opt => opt.MapFrom(employee => employee.SureName))
                .ForMember(employeeDto => employeeDto.Position, opt => opt.MapFrom(employee => employee.Position));
        }
    }
}