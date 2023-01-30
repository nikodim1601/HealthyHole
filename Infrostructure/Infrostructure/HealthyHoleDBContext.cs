using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using HealthyHole.Dal.EntityConfigurations;

namespace Infrastructure
{
    public class HealthyHoleDBContext : DbContext, IHealthyHoleDBContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FactoryShift> FactoryChanges { get; set; }

        public HealthyHoleDBContext(DbContextOptions<HealthyHoleDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Добавляем наши конфигурации.
            builder.ApplyConfiguration(new EmployeeConfiguration());
            // Эта строчка является костылем.
            // https://stackoverflow.com/questions/74923874/the-database-operation-was-expected-to-affect-1-rows-but-actually-affected-0
            builder.Entity<FactoryShift>().Property(employee => employee.Id ).ValueGeneratedNever();
            // builder.Entity<FactoryShift>().HasOne(shift => shift.Employee).WithMany(employee => employee.FactoryShift);
            base.OnModelCreating(builder);
        }
    }
}