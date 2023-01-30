using System;
using MediatR;

namespace HealthyHole.Application.Commands.EmployeeCommands
{
    public class DeleteEmployeeCommand : IRequest<Guid>
    {
        public Guid EmployeeId { get; }

        public DeleteEmployeeCommand(Guid employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}