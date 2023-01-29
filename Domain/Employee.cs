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
        private Constants.Positions _position;
        private IReadOnlyList<FactoryShift> _factoryShift;

        public Guid Id
        {
            get;
            init;
        }

        public string SecondName
        {
            get => _secondName;
            init => _secondName = value;
        }

        public string FirstName
        {
            get => _firstName;
            init => _firstName = value;
        }

        public string SureName
        {
            get => _sureName;
            init => _sureName = value;
        }

        public Constants.Positions Position
        {
            get => _position;
            init => _position = value;
        }

        public IReadOnlyList<FactoryShift> FactoryShift
        {
            get => _factoryShift;
            init => _factoryShift = value;
        }

        public void UpdateEmployee(string firstName, string secondName, string sureName, Constants.Positions positions)
        {
            _firstName = firstName;
            _secondName = secondName;
            _sureName = sureName;
            _position = positions;
        }
    }
}