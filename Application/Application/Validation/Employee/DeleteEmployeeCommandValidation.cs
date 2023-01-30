using System;
using FluentValidation;
using HealthyHole.Application.Commands.Emploee;

namespace HealthyHole.Application.Rules.Employee
{
    /// <summary>
    /// Определяет правило удаления сотрудника.
    /// </summary>
    public class DeleteEmployeeCommandRule : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandRule()
        {
            RuleFor(command => command.EmployeeId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}