using System;

namespace HealthyHole.Domain.Exceptions
{
    /// <summary>
    /// Ошибка возникает если работник не закрыл предыдущую смену.
    /// </summary>
    public class LastShiftNotClosedException : SystemException
    {
        public LastShiftNotClosedException(string message) : base(message)
        {
        }
    }
}