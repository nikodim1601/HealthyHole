using Application;
using HealthyHole.Application.Commands.Emploee;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HealthyHole.Application.Exceptions;

namespace HealthyHole.Application.CommandHandlers
{
    internal class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Guid>
    {
        private readonly IHealthyHoleDBContext _dbContext;

        public DeleteEmployeeCommandHandler(IHealthyHoleDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Guid> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emploee = await _dbContext.Employees.FirstOrDefaultAsync(emploee => emploee.Id == request.EmployeeId);

            if (emploee == null)
            {
                throw new EmployeeNotFoundException($"Заводчага с позывным {request.EmployeeId} не обнаружен.");
            }

            _dbContext.Employees.Remove(emploee);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return emploee.Id;
        }
    }
}
