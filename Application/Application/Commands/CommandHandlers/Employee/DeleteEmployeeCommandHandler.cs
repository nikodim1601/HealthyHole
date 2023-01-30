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
    internal class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Guid>
    {
        private readonly IHealthyHoleDbContext _dbContext;

        public DeleteEmployeeCommandHandler(IHealthyHoleDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Guid> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(employee => employee.Id == request.EmployeeId,
                cancellationToken: cancellationToken);

            if (employee == null)
            {
                throw new EmployeeNotFoundException($"Заводчага с позывным {request.EmployeeId} не обнаружен.");
            }

            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }
    }
}