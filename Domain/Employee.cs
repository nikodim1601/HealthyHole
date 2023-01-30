using System;
using System.Collections.Generic;
using System.Linq;
using HealthyHole.Domain.Exceptions;

namespace HealthyHole.Domain
{
    /// <summary>
    /// Представляет класс "Сотрудника".
    /// </summary>
    public class Employee
    {
        private string _secondName;
        private string _firstName;
        private string _sureName;
        private Constants.Positions _position;
        private readonly List<FactoryShift> _factoryShifts = new();

        public Guid Id { get; init; }

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
            get => _factoryShifts;
            init => _factoryShifts = value as List<FactoryShift>;
        }

        /// <summary>
        /// Обновляет информацию о пользователе.
        /// </summary>
        public void UpdateEmployee(string firstName, string secondName, string sureName, Constants.Positions positions)
        {
            _firstName = firstName;
            _secondName = secondName;
            _sureName = sureName;
            _position = positions;
        }

        /// <summary>
        /// Начинает смену.
        /// </summary>
        /// <exception cref="LastShiftNotClosedException">Ошибка возникает если работник не закрыл предыдущую смену.</exception>
        public void StartShift(DateTime startTime)
        {
            var yesterday = startTime.Date.AddDays(-1);
            var todayShift = GetShiftByDay(DateTime.Now);

            // Для самой первой смены пропускаем проверку
            if (_factoryShifts.Count > 0)
            {
                var lastShift = GetShiftByDay(yesterday);

                if (lastShift?.FinishTime is null)
                {
                    throw new LastShiftNotClosedException($"От {_sureName}'ич, номер {Id}, опять смену не закрыл.");
                }    
            }
            

            if (todayShift is not null)
            {
                todayShift.StartTime = startTime;
            }
            else
            {
                _factoryShifts.Add(new FactoryShift()
                {
                    Employee = this,
                    Id = Guid.NewGuid(),
                    StartTime = startTime
                });
            }
        }

        /// <summary>
        /// Завершает смену.
        /// </summary>
        /// <exception cref="ShiftNotStartedException">Ошибка возникает, если пользователь не начал смену, но пытается ее завершить. </exception>
        public void FinishShift(DateTime finishTime)
        {
            var todayShift = GetShiftByDay(finishTime.Date);

            if (todayShift is null)
            {
                throw new ShiftNotStartedException($"{_sureName}'ич, номер {Id}, смену не начинал падла.");
            }

            todayShift.FinishTime = finishTime;
            todayShift.WorkedHours = (todayShift.FinishTime - todayShift.StartTime)?.Hours;
        }

        private FactoryShift GetShiftByDay(DateTime day)
        {
            return _factoryShifts.FirstOrDefault(shift => shift.StartTime != null && shift.StartTime.Value.Date == day);
        }
    }
}