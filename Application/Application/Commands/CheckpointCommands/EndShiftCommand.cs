using System;
using MediatR;

namespace HealthyHole.Application.Commands.CheckpointCommands
{
    public class EndShiftCommand : IRequest<Unit>
    {
        public Guid EmployeeId { get; init; }
        public DateTime EndShift { get; init; }
    }
}