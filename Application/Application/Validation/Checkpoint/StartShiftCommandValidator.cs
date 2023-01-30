using FluentValidation;
using HealthyHole.Application.Commands.CheckpointCommands;

namespace HealthyHole.Application.Validation.Checkpoint
{
    /// <summary>
    /// Определяет правило добавления сотрудника.
    /// </summary>
    public class StartShiftCommandValidator : AbstractValidator<StartShiftCommand>
    {
        public StartShiftCommandValidator()
        {
            RuleFor(command => command.EmployeeId).NotEmpty();
            RuleFor(command => command.StartShift).NotEmpty();
        }
    }
}