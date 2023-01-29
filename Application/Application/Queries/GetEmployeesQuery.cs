using HealthyHole.Application.Queries.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace HealthyHole.Application.Queries
{
    public class GetEmployeesQuery : IRequest<EmploeesList>
    {
        public Constants.Positions? Positions { get; set; }
    }
}
