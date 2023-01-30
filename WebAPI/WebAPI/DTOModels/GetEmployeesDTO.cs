using Application;
using AutoMapper;
using Domain;
using HealthyHole.Application.Commands.Emploee;
using HealthyHole.Application.Queries;

namespace HealthyHole.WebAPI.Models
{
    public class GetEmployeesDTO : IMapWith<GetEmployeesDTO>
    {
        public Constants.Positions Position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetEmployeesDTO, GetEmployeesQuery>().ForMember(
                employeeDTO => employeeDTO.Positions,
                opt => opt.MapFrom(employee => employee.Position));
        }
    }
}