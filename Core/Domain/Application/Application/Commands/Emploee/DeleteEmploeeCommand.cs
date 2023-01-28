using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyHole.Application.Commands.Emploee
{
    public class DeleteEmploeeCommand : IRequest<Guid>
    {
        public Guid EmploeeId { get; }

        public DeleteEmploeeCommand(Guid emploeeId)
        {
            EmploeeId = emploeeId;
        }
    }
}
