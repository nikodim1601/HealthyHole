using FluentValidation;
using HealthyHole.Application.Queries;

namespace HealthyHole.Application.Validation.Employee
{
    /// <summary>
    /// Определяет запрос получения сотруднков.
    /// </summary>
    public class GetEmployeesQueryRule : AbstractValidator<GetEmployeesQuery>
    {
        public GetEmployeesQueryRule()
        {
            RuleFor(command => command.Positions).IsInEnum();
        }
    }
}