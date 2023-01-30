using System;

namespace HealthyHole.Domain.Exceptions
{
    /// <summary>
    /// Ошибка возникает, если пользователь не начал смену, но пытается ее завершить.
    /// </summary>
    public class ShiftNotStartedException : SystemException
    {
        public ShiftNotStartedException(string message) : base(message)
        {
        }
    }
}