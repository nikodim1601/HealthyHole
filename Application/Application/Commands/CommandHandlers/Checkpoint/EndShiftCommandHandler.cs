using System;
using System.Threading;
using System.Threading.Tasks;
using Application;
using Domain;
using HealthyHole.Application.Commands.CheckpointCommands;
using HealthyHole.Application.Commands.Emploee;
using MediatR;

namespace HealthyHole.Application.Commands.CommandHandlers.Checkpoint
{
    // public class EndShiftCommandHandler : IRequestHandler<EndShiftCommand>
    // {
    //     private readonly IHealthyHoleDBContext _dbContext;
    //
    //     public EndShiftCommandHandler(IHealthyHoleDBContext dbContext)
    //     {
    //         _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    //     }
    //     public Task<Unit> Handle(EndShiftCommand request, CancellationToken cancellationToken)
    //     {
    //
    //         return Task.FromResult();
    //     }
    //     
    // }
}