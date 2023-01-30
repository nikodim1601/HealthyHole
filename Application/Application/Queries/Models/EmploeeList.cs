using System.Collections.Generic;

namespace HealthyHole.Application.Queries.Models
{
    public class EmploeesList
    {
        public IList<EmploeeDTO> Emploees { get; }

        public EmploeesList(IList<EmploeeDTO> emploees)
        {
            Emploees = emploees;
        }
    }
}