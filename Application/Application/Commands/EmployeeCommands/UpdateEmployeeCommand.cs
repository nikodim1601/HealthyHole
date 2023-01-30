using System;
using HealthyHole.Domain;
using MediatR;

namespace HealthyHole.Application.Commands.EmployeeCommands
{
    public class UpdateEmployeeCommand : IRequest<Employee>
    {
        public Guid EmployeeId { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public Domain.Constants.Positions Position { get; set; }
    }
}