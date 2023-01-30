using System;
using Application;
using AutoMapper;
using HealthyHole.Application.Commands.CheckpointCommands;
using HealthyHole.Application.Commands.Emploee;
using HealthyHole.WebAPI.Models;

namespace HealthyHole.WebAPI.DTOModels
{
    public class EndShiftDTO : IMapWith<EndShiftDTO>
    {
        public Guid EmployeeId { get; set; }
        public DateTime EndTime { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EndShiftDTO, EndShiftCommand>().ForMember(
                    employeeDTO => employeeDTO.EmployeeId,
                    opt => opt.MapFrom(employee => employee.EmployeeId))
                .ForMember(employeeDTO => employeeDTO.EndShift, opt => opt.MapFrom(employee => employee.EndTime));
        }

    }
}