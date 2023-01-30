using System;
using AutoMapper;
using HealthyHole.Application;
using HealthyHole.Application.Commands.CheckpointCommands;
using HealthyHole.Application.Interfaces;

namespace HealthyHole.WebAPI.DTOModels
{
    public class StartShiftDto : IMapWith<StartShiftDto>
    {
        public Guid EmployeeId { get; set; }
        public DateTime StartTime { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StartShiftDto, StartShiftCommand>().ForMember(
                    employeeDto => employeeDto.EmployeeId,
                    opt => opt.MapFrom(employee => employee.EmployeeId))
                .ForMember(employeeDto => employeeDto.StartShift, opt => opt.MapFrom(employee => employee.StartTime));
        }

    }
}