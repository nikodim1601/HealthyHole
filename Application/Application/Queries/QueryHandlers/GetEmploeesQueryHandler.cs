using Application;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using HealthyHole.Application.Commands.Emploee;
using HealthyHole.Application.Queries.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HealthyHole.Application.Queries.QueryHandlers
{
    internal class GetEmploeesQueryHandler : IRequestHandler<GetEmploeesQuery, EmploeesList>
    {
        private readonly IHealthyHoleDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmploeesQueryHandler(IHealthyHoleDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EmploeesList> Handle(GetEmploeesQuery request, CancellationToken cancellationToken)
        {
            var emploees = await _dbContext.Employees
                .ProjectTo<EmploeeDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new EmploeesList(emploees);
        }
    }
}
