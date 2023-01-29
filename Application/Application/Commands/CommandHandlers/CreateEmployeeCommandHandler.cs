using Application;
using Domain;
using HealthyHole.Application.Commands.Emploee;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HealthyHole.Application.CommandHandlers
{
    internal class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IHealthyHoleDBContext _dbContext;

        public CreateEmployeeCommandHandler(IHealthyHoleDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Id = request.EmployeeId,
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                SureName = request.SureName,
                Position = request.Position,
            };

            await _dbContext.Employees.AddAsync(employee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return employee;
        }
    }
}
