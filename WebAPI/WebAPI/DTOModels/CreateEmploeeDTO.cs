using Application;
using AutoMapper;
using Domain;
using HealthyHole.Application.Commands.Emploee;
using System;

namespace HealthyHole.WebAPI.Models
{
    public class CreateEmploeeDTO : IMapWith<CreateEmploeeDTO>
    {
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public Constants.Positions? Position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmploeeDTO, CreateEmployeeCommand>().ForMember(
                    employeeDTO => employeeDTO.SecondName,
                    opt => opt.MapFrom(employee => employee.SecondName))
                .ForMember(employeeDTO => employeeDTO.FirstName, opt => opt.MapFrom(employee => employee.FirstName))
                .ForMember(employeeDTO => employeeDTO.SureName, opt => opt.MapFrom(employee => employee.SureName))
                .ForMember(employeeDTO => employeeDTO.Position, opt => opt.MapFrom(employee => employee.Position));
        }
    }
}