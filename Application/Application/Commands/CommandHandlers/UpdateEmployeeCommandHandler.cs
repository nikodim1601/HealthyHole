using Application;
using Domain;
using HealthyHole.Application.Commands.Emploee;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HealthyHole.Application.CommandHandlers
{
    internal class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly IHealthyHoleDBContext _dbContext;

        public UpdateEmployeeCommandHandler(IHealthyHoleDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(empl => empl.Id == request.EmployeeId, cancellationToken);

            if (employee == null)
            {
                throw new NullReferenceException($"Заводчага {request.FirstName} {request.SecondName} с позывным {request.EmployeeId} не обнаружен.");
            }

            employee.FirstName = request.FirstName;
            employee.SecondName = request.SecondName;
            employee.SureName = request.SureName;
            employee.Position = request.Position;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return employee;
        }
    }
}
