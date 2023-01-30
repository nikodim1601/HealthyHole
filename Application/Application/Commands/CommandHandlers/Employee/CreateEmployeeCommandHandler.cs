using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HealthyHole.Application.Commands.EmployeeCommands;
using HealthyHole.Application.Interfaces;
using HealthyHole.Domain;
using MediatR;

namespace HealthyHole.Application.Commands.CommandHandlers.Employee
{
    internal class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Domain.Employee>
    {
        private readonly IHealthyHoleDbContext _dbContext;

        public CreateEmployeeCommandHandler(IHealthyHoleDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Domain.Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Domain.Employee
            {
                Id = request.EmployeeId,
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                SureName = request.SureName,
                Position = request.Position,
                FactoryShift = new List<FactoryShift>()
            };

            await _dbContext.Employees.AddAsync(employee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return employee;
        }
    }
}