using Application;
using AutoMapper;
using Domain;
using HealthyHole.Application.Commands.Emploee;
using System;

namespace HealthyHole.WebAPI.Models
{
    public class UpdateEmploeeDTO : IMapWith<UpdateEmploeeDTO>
    {
        public Guid EmploeeId { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public Constants.Posistions Position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEmploeeDTO, UpdateEmployeeCommand>().ForMember(employeeDTO => employeeDTO.EmploeeId,
                    opt => opt.MapFrom(employee => employee.EmploeeId))
                .ForMember(employeeDTO => employeeDTO.SecondName, opt => opt.MapFrom(employee => employee.SecondName))
                .ForMember(employeeDTO => employeeDTO.FirstName, opt => opt.MapFrom(employee => employee.FirstName))
                .ForMember(employeeDTO => employeeDTO.SureName, opt => opt.MapFrom(employee => employee.SureName))
                .ForMember(employeeDTO => employeeDTO.Position, opt => opt.MapFrom(employee => employee.Position));
        }
    }
}