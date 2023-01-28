using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public interface IHealthyHoleDBContext
    {
        DbSet<Employee> Employees { get; }
        DbSet<FactoryChange> FactoryChanges { get; }

        /// <summary>
        /// Сохраняет изменение контекста в DB. 
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
