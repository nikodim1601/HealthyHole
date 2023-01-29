using System;
using MediatR;

namespace HealthyHole.Application.Commands.CheckpointCommands
{
    public class StartShiftCommand : IRequest<Unit>
    {
        public Guid EmployeeId { get; }

        public StartShiftCommand(Guid employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}