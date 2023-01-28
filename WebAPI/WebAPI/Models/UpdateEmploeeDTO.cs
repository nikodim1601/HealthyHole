using Application;
using AutoMapper;
using Domain;
using HealthyHole.Application.Commands.Emploee;
using System;

namespace HealthyHole.WebAPI.Models
{
    public class UpdateEmploeeDTO : IMapWith<UpdateEmploeeDTO>
    {
        public Guid EmploeeId { get; }
        public string SecondName { get; }
        public string FirstName { get; }
        public string SureName { get; }
        public Constants.Posistions Position { get; }
        public FactoryChange[] FactoryChanges { get; }

        UpdateEmploeeDTO(Guid emploeeId, string secondName, string firstName, string sureName, Constants.Posistions position, FactoryChange[] factoryChanges)
        {
            EmploeeId = emploeeId;
            SecondName = secondName;
            FirstName = firstName;
            SureName = sureName;
            Position = position;
            FactoryChanges = factoryChanges;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEmploeeDTO, UpdateEmploeeCommand>().ForMember(emploeeDTO => emploeeDTO.EmploeeId, opt => opt.MapFrom(emploee => emploee.EmploeeId))
                .ForMember(emploeeDTO => emploeeDTO.SecondName, opt => opt.MapFrom(emploee => emploee.SecondName))
                .ForMember(emploeeDTO => emploeeDTO.FirstName, opt => opt.MapFrom(emploee => emploee.FirstName))
                .ForMember(emploeeDTO => emploeeDTO.SureName, opt => opt.MapFrom(emploee => emploee.SureName))
                .ForMember(emploeeDTO => emploeeDTO.Position, opt => opt.MapFrom(emploee => emploee.Position))
                .ForMember(emploeeDTO => emploeeDTO.FactoryChanges, opt => opt.MapFrom(emploee => emploee.FactoryChanges));
        }
    }
}
