using System;
using MediatR;

namespace HealthyHole.Application.Commands.CheckpointCommands
{
    public class EndShiftCommand : IRequest<Unit>
    {
        public Guid EmployeeId { get; }

        public EndShiftCommand(Guid employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}