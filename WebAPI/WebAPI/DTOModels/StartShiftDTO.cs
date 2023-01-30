using System;
using Application;
using AutoMapper;
using HealthyHole.Application.Commands.CheckpointCommands;
using HealthyHole.WebAPI.DTOModels;

namespace HealthyHole.WebAPI.Models
{
    public class StartShiftDTO : IMapWith<StartShiftDTO>
    {
        public Guid EmployeeId { get; set; }
        public DateTime StartTime { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StartShiftDTO, StartShiftCommand>().ForMember(
                    employeeDTO => employeeDTO.EmployeeId,
                    opt => opt.MapFrom(employee => employee.EmployeeId))
                .ForMember(employeeDTO => employeeDTO.StartShift, opt => opt.MapFrom(employee => employee.StartTime));
        }

    }
}