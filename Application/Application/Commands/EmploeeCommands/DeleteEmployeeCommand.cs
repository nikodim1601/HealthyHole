using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyHole.Application.Commands.Emploee
{
    public class DeleteEmployeeCommand : IRequest<Guid>
    {
        public Guid EmployeeId { get; }

        public DeleteEmployeeCommand(Guid employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}