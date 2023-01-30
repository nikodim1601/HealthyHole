using System;
using FluentValidation;
using HealthyHole.Application.Commands.EmployeeCommands;

namespace HealthyHole.Application.Validation.Employee
{
    /// <summary>
    /// Определяет валидацию для команды удаления сотрудника.
    /// </summary>
    public class DeleteEmployeeCommandRule : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandRule()
        {
            RuleFor(command => command.EmployeeId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}