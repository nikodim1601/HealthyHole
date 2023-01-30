using System;
using HealthyHole.Domain;
using MediatR;

namespace HealthyHole.Application.Commands.EmployeeCommands
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public Guid EmployeeId { get; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public Domain.Constants.Positions Position { get; set; }

        CreateEmployeeCommand()
        {
            EmployeeId = Guid.NewGuid();
        }
    }
}