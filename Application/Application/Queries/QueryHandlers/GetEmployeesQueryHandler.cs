using AutoMapper;
using AutoMapper.QueryableExtensions;
using HealthyHole.Application.Queries.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HealthyHole.Application.DTO;
using HealthyHole.Application.Interfaces;

namespace HealthyHole.Application.Queries.QueryHandlers
{
    internal class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, EmployeeList>
    {
        private readonly IHealthyHoleDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmployeesQueryHandler(IHealthyHoleDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EmployeeList> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            List<EmployeeDto> employees;

            if (request.Positions is not null)
            {
                employees = await _dbContext.Employees.Where(employee => employee.Position == request.Positions)
                    .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken: cancellationToken);
            }
            else
            {
                employees = await _dbContext.Employees
                    .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken: cancellationToken);
            }

            return new EmployeeList(employees);
        }
    }
}