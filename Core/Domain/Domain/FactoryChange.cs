using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Представляет класс "Смены".
    /// </summary>
    public class FactoryChange
    {
        private Guid _id = Guid.NewGuid();
        private DateTime _startTime;
        private DateTime _finishTime;
        private int _workedHours;
        private Employee _employee;


        public Guid Id { get => _id; }
        public DateTime StartTime { get => _startTime; }
        public DateTime FinishTime { get => _finishTime; }
        public int WorkedHours { get => _workedHours; }
        public Employee Employee { get => _employee; }

        //public FactoryChange(Employee employee)
        //{
        //    _employee = employee ?? throw new ArgumentNullException(nameof(employee));
        //}
    }
}
