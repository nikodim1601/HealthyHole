using HealthyHole.Application;
using HealthyHole.Application.Interfaces;
using HealthyHole.Dal.EntityConfigurations;
using HealthyHole.Domain;
using Microsoft.EntityFrameworkCore;

namespace HealthyHole.Dal
{
    public class HealthyHoleDbContext : DbContext, IHealthyHoleDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FactoryShift> FactoryChanges { get; set; }

        public HealthyHoleDbContext(DbContextOptions<HealthyHoleDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Добавляем наши конфигурации.
            builder.ApplyConfiguration(new EmployeeConfiguration());
            
            // Эта строчка является костылем.
            // https://stackoverflow.com/questions/74923874/the-database-operation-was-expected-to-affect-1-rows-but-actually-affected-0
            builder.Entity<FactoryShift>().Property(employee => employee.Id ).ValueGeneratedNever();
            
            base.OnModelCreating(builder);
        }
    }
}