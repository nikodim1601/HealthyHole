using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HealthyHole.Application.Commands.Emploee
{
    public class CreateEmploeeCommand : IRequest<Guid>
    {
        public Guid EmploeeId { get; }
        public string SecondName { get; }
        public string FirstName { get; }
        public string SureName { get; }
        public Constants.Posistions Position { get; }
        public FactoryChange[] FactoryChanges { get; }

        CreateEmploeeCommand(Guid emploeeId, string secondName, string firstName, string sureName, Constants.Posistions position, FactoryChange[] factoryChanges)
        {
            EmploeeId = emploeeId;
            SecondName = secondName;
            FirstName = firstName;
            SureName = sureName;
            Position = position;
            FactoryChanges = factoryChanges;
        }
    }
}
