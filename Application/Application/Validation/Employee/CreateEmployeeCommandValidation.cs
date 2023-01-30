using FluentValidation;
using HealthyHole.Application.Commands.Emploee;

namespace HealthyHole.Application.Validation.Employee
{
    /// <summary>
    /// Определяет правило добавления сотрудника.
    /// </summary>
    public class CreateEmployeeCommandRule : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandRule()
        {
            RuleFor(command => command.FirstName).NotEmpty();
            RuleFor(command => command.SecondName).NotEmpty();
            RuleFor(command => command.Position).NotNull().IsInEnum();
        }
    }
}