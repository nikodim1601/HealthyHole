using System;
using System.Threading;
using System.Threading.Tasks;
using HealthyHole.Application.Commands.EmployeeCommands;
using HealthyHole.Application.Exceptions;
using HealthyHole.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HealthyHole.Application.Commands.CommandHandlers.Employee
{
    internal class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Domain.Employee>
    {
        private readonly IHealthyHoleDbContext _dbContext;

        public UpdateEmployeeCommandHandler(IHealthyHoleDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Domain.Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee =
                await _dbContext.Employees.FirstOrDefaultAsync(empl => empl.Id == request.EmployeeId,
                    cancellationToken);

            if (employee == null)
            {
                throw new EmployeeNotFoundException(
                    $"Заводчага {request.FirstName} {request.SecondName} с позывным {request.EmployeeId} не обнаружен.");
            }

            employee.UpdateEmployee(request.FirstName, request.SecondName, request.SureName, request.Position);
            
            await _dbContext.SaveChangesAsync(cancellationToken);

            return employee;
        }
    }
}