using Application;
using Domain;
using HealthyHole.Application.Commands.Emploee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HealthyHole.Application.CommandHandlers
{
    internal class CreateEmploeeCommandHandler : IRequestHandler<CreateEmploeeCommand, Guid>
    {
        private readonly IHealthyHoleDBContext _dbContext;

        public CreateEmploeeCommandHandler(IHealthyHoleDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Guid> Handle(CreateEmploeeCommand request, CancellationToken cancellationToken)
        {
            // var emploee = new Employee(request.EmploeeId, request.SecondName, request.FirstName, request.SureName, request.Position, request.FactoryChanges);
            var emploee = new Employee();
            emploee.Id = request.EmploeeId;
            emploee.FirstName = request.FirstName;
            emploee.SureName = request.SureName;
            emploee.FactoryChanges = request.FactoryChanges;
            emploee.Position = request.Position;

            await _dbContext.Employees.AddAsync(emploee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return emploee.Id;
        }
    }
}
