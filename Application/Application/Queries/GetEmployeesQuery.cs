using HealthyHole.Application.Queries.Models;
using MediatR;

namespace HealthyHole.Application.Queries
{
    public class GetEmployeesQuery : IRequest<EmployeeList>
    {
        public Domain.Constants.Positions? Positions { get; set; }
    }
}