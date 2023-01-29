using Application;
using Domain;
using Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class HealthyHoleDBContext : DbContext, IHealthyHoleDBContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FactoryChange> FactoryChanges { get; set; }

        public HealthyHoleDBContext(DbContextOptions<HealthyHoleDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Добавляем наши конфигурации.
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new FactoryChangeConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
