using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HealthyHole.Application.Commands.CheckpointCommands;
using HealthyHole.Application.DTO;
using HealthyHole.Application.Exceptions;
using HealthyHole.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HealthyHole.Application.Commands.CommandHandlers.Checkpoint
{
    public class EndShiftCommandHandler : IRequestHandler<EndShiftCommand>
    {
        private readonly IHealthyHoleDbContext _dbContext;
        private readonly IMapper _mapper;

        public EndShiftCommandHandler(IHealthyHoleDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(EndShiftCommand request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(employee => employee.Id == request.EmployeeId,
                cancellationToken: cancellationToken);

            // Тут есть баг, я не доразобрался с ним, по этому тут вот это. Изначально я получаю работника без "смен". 
            await _dbContext.Employees
                .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(
                    employeeDto => employeeDto.EmployeeId == request.EmployeeId, cancellationToken: cancellationToken);
            
            if (employee == null)
            {
                throw new EmployeeNotFoundException($"Заводчага с позывным {request.EmployeeId} не обнаружен.");
            }
            
            employee.FinishShift(request.EndShift);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}