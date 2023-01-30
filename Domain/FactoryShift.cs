using System;

namespace HealthyHole.Domain
{
    /// <summary>
    /// Представляет класс "Смены".
    /// </summary>
    public class FactoryShift
    {
        public Guid Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public int? WorkedHours { get; set; }
        public Employee Employee { get; set; }
    }
}