using FluentValidation;
using HealthyHole.Application.Commands.CheckpointCommands;

namespace HealthyHole.Application.Validation.Checkpoint
{
    public class EndShiftCommandValidator :  AbstractValidator<EndShiftCommand>
    {
        public EndShiftCommandValidator()
        {
            RuleFor(command => command.EmployeeId).NotEmpty();
            RuleFor(command => command.EndShift).NotEmpty();
        }   
    }
}