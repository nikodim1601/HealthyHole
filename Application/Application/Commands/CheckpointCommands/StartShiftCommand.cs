using System;
using MediatR;

namespace HealthyHole.Application.Commands.CheckpointCommands
{
    public class StartShiftCommand : IRequest<Unit>
    {
        public Guid EmployeeId { get; init; }
        public DateTime StartShift { get; init; }
    }
}