using Domain;
using MediatR;
using System;

namespace HealthyHole.Application.Commands.Emploee
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public Guid EmployeeId { get; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public Constants.Posistions Position { get; set; }

        CreateEmployeeCommand()
        {
            EmployeeId = Guid.NewGuid();
        }
    }
}
