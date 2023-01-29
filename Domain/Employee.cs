using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Представляет класс "Сотрудника".
    /// </summary>
    public class Employee
    {
        public Guid Id { get; set; }

        public string SecondName { get; set; }

        public string FirstName { get; set; }

        public string SureName { get; set; }

        public Constants.Posistions Position { get; set; }

        public FactoryChange[] FactoryChanges { get; set; }
    }
}