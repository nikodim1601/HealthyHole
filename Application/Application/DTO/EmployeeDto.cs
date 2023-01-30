using System;
using AutoMapper;
using HealthyHole.Application.Interfaces;
using HealthyHole.Domain;

namespace HealthyHole.Application.DTO
{
    public class EmployeeDto : IMapWith<Employee>
    {
        public Guid EmployeeId { get; private set; }
        public string SecondName { get; private set; }
        public string FirstName { get; private set; }
        public string SureName { get; private set; }
        public Domain.Constants.Positions Position { get; private set; }
        public FactoryShift[] FactoryChanges { get; private set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDto>().ForMember(employeeDto => employeeDto.EmployeeId,
                    opt => opt.MapFrom(employee => employee.Id))
                .ForMember(employeeDto => employeeDto.SecondName, opt => opt.MapFrom(employee => employee.SecondName))
                .ForMember(employeeDto => employeeDto.FirstName, opt => opt.MapFrom(employee => employee.FirstName))
                .ForMember(employeeDto => employeeDto.SureName, opt => opt.MapFrom(employee => employee.SureName))
                .ForMember(employeeDto => employeeDto.Position, opt => opt.MapFrom(employee => employee.Position))
                .ForMember(employeeDto => employeeDto.FactoryChanges,
                    opt => opt.MapFrom(employee => employee.FactoryShift));
        }
    }
}