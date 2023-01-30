using System;
using FluentValidation;
using HealthyHole.Application.Commands.EmployeeCommands;

namespace HealthyHole.Application.Rules.Employee
{
    /// <summary>
    /// Определяет валидацию для команды обновления информации о сотруднике
    /// </summary>
    public class UpdateEmployeeCommandRule : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandRule()
        {
            RuleFor(command => command.EmployeeId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(command => command.FirstName).NotEmpty();
            RuleFor(command => command.SecondName).NotEmpty();
            RuleFor(command => command.Position).NotNull().IsInEnum();
        }
    }
}