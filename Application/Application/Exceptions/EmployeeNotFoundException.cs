using System;

namespace HealthyHole.Application.Exceptions
{
    /// <summary>
    /// Ошибка возникает сотрудник не найдет.
    /// </summary>
    public class EmployeeNotFoundException : SystemException
    {
        public EmployeeNotFoundException(string message) : base(message)
        {
        }
    }
}