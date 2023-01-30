using Application;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyHole.Application.Queries
{
    public class EmploeeDTO : IMapWith<Employee>
    {
        public Guid EmploeeId { get; private set; }
        public string SecondName { get; private set; }
        public string FirstName { get; private set; }
        public string SureName { get; private set; }
        public Constants.Positions Position { get; private set; }
        public FactoryShift[] FactoryChanges { get; private set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmploeeDTO>().ForMember(emploeeDTO => emploeeDTO.EmploeeId,
                    opt => opt.MapFrom(emploee => emploee.Id))
                .ForMember(emploeeDTO => emploeeDTO.SecondName, opt => opt.MapFrom(emploee => emploee.SecondName))
                .ForMember(emploeeDTO => emploeeDTO.FirstName, opt => opt.MapFrom(emploee => emploee.FirstName))
                .ForMember(emploeeDTO => emploeeDTO.SureName, opt => opt.MapFrom(emploee => emploee.SureName))
                .ForMember(emploeeDTO => emploeeDTO.Position, opt => opt.MapFrom(emploee => emploee.Position))
                .ForMember(emploeeDTO => emploeeDTO.FactoryChanges,
                    opt => opt.MapFrom(emploee => emploee.FactoryShift));
        }
    }
}