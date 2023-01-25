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
    
        private Guid _id;
        private string _secondName;
        private string _firstName;
        private string _sureName;
        private Position.Posistions _position;
        private FactoryChange[] _factoryChanges;


        public Guid Id { get => _id; }
        public string SecondName { get => _secondName; }
        public string FirstName { get => _firstName; }
        public string SureName { get => _sureName; }
        public Position.Posistions Position { get => _position; }
        public FactoryChange[] FactoryChanges { get=> _factoryChanges; }

        public Employee(Position.Posistions position, FactoryChange[] factoryChanges)
        {
            _factoryChanges = factoryChanges ?? throw new ArgumentNullException(nameof(factoryChanges));
            _position = position;
        }
    }
}
