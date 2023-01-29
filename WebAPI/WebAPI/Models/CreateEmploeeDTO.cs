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
        public Constants.Posistions? Position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmploeeDTO, CreateEmployeeCommand>().ForMember(emploeeDTO => emploeeDTO.SecondName,
                    opt => opt.MapFrom(emploee => emploee.SecondName))
                .ForMember(emploeeDTO => emploeeDTO.FirstName, opt => opt.MapFrom(emploee => emploee.FirstName))
                .ForMember(emploeeDTO => emploeeDTO.SureName, opt => opt.MapFrom(emploee => emploee.SureName))
                .ForMember(emploeeDTO => emploeeDTO.Position, opt => opt.MapFrom(emploee => emploee.Position));
        }
    }
}