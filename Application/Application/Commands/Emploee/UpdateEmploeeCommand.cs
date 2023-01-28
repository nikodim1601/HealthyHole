using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyHole.Application.Commands.Emploee
{
    public class UpdateEmploeeCommand : IRequest<Guid>
    {
        public Guid EmploeeId { get; }
        public string SecondName { get; private set; }
        public string FirstName { get; private set; }
        public string SureName { get; private set; }
        public Constants.Posistions Position { get; private set; }
        public FactoryChange[] FactoryChanges { get; private set; }

        UpdateEmploeeCommand(Guid emploeeId, string secondName, string firstName, string sureName, Constants.Posistions position, FactoryChange[] factoryChanges)
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
