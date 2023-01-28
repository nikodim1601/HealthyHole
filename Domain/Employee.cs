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
        private Constants.Posistions _position;
        private FactoryChange[] _factoryChanges;

        public Guid Id { get => _id; set => _id = value; }
        public string SecondName { get => _secondName; set => _secondName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string SureName { get => _sureName; set => _sureName = value; }
        public Constants.Posistions Position { get => _position; set => _position = value; }
        public FactoryChange[] FactoryChanges { get=> _factoryChanges; set => _factoryChanges = value; }


        // TODO here
        //public Employee(Guid id, string secondName, string firstName, string sureName, Constants.Posistions position, FactoryChange[] factoryChanges)
        //{
        //    _id = id;
        //    _position = position;
        //    _secondName = secondName ?? throw new ArgumentNullException(nameof(secondName));
        //    _firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        //    _sureName = sureName ?? throw new ArgumentNullException(nameof(sureName));
        //    _factoryChanges = factoryChanges ?? throw new ArgumentNullException(nameof(factoryChanges));
        //}
    }
}
