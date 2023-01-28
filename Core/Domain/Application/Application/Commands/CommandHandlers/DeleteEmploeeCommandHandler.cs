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

namespace HealthyHole.Application.CommandHandlers
{
    internal class DeleteEmploeeCommandHandler : IRequestHandler<DeleteEmploeeCommand, Guid>
    {
        private readonly IHealthyHoleDBContext _dbContext;

        public DeleteEmploeeCommandHandler(IHealthyHoleDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Guid> Handle(DeleteEmploeeCommand request, CancellationToken cancellationToken)
        {
            var emploee = await _dbContext.Employees.FirstOrDefaultAsync(emploee => emploee.Id == request.EmploeeId);

            if (emploee == null)
            {
                throw new NullReferenceException($"Заводчага с позывным {request.EmploeeId} не обнаружен.");
            }

            _dbContext.Employees.Remove(emploee);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return emploee.Id;
        }
    }
}
