using System.Threading;
using System.Threading.Tasks;
using HealthyHole.Domain;
using Microsoft.EntityFrameworkCore;

namespace HealthyHole.Application.Interfaces
{
    public interface IHealthyHoleDbContext
    {
        DbSet<Employee> Employees { get; }
        DbSet<FactoryShift> FactoryChanges { get; }

        /// <summary>
        /// Сохраняет изменение контекста в DB. 
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}