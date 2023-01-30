using System.Collections.Generic;
using HealthyHole.Application.DTO;

namespace HealthyHole.Application.Queries.Models
{
    public class EmployeeList
    {
        public IList<EmployeeDto> Employees { get; }

        public EmployeeList(IList<EmployeeDto> employees)
        {
            Employees = employees;
        }
    }
}