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
    internal class UpdateEmploeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Guid>
    {
        private readonly IHealthyHoleDBContext _dbContext;

        public UpdateEmploeeCommandHandler(IHealthyHoleDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Guid> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emploee = await _dbContext.Employees.FirstOrDefaultAsync(emploee => emploee.Id == request.EmploeeId, cancellationToken);

            if (emploee == null)
            {
                throw new NullReferenceException($"Заводчага {request.FirstName} {request.SecondName} с позывным {request.EmploeeId} не обнаружен.");
            }

            emploee.FirstName = request.FirstName;
            emploee.SecondName = request.SecondName;
            emploee.SureName = request.SureName;
            emploee.FactoryChanges = request.FactoryChanges;
            emploee.Position = request.Position;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return emploee.Id;
        }
    }
}
