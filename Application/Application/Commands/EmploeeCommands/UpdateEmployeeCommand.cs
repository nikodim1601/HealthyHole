using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyHole.Application.Commands.Emploee
{
    public class UpdateEmployeeCommand : IRequest<Employee>
    {
        public Guid EmployeeId { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public Constants.Positions Position { get; set; }
    }
}