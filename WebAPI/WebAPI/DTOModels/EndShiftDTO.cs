using System;
using AutoMapper;
using HealthyHole.Application;
using HealthyHole.Application.Commands.CheckpointCommands;
using HealthyHole.Application.Interfaces;

namespace HealthyHole.WebAPI.DTOModels
{
    public class EndShiftDto : IMapWith<EndShiftDto>
    {
        public Guid EmployeeId { get; set; }
        public DateTime EndTime { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EndShiftDto, EndShiftCommand>().ForMember(
                    employeeDto => employeeDto.EmployeeId,
                    opt => opt.MapFrom(employee => employee.EmployeeId))
                .ForMember(employeeDto => employeeDto.EndShift, opt => opt.MapFrom(employee => employee.EndTime));
        }

    }
}