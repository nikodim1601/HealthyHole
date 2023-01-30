using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthyHole.Dal.EntityConfigurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Определяет что является ключем записи.
            builder.HasKey(employee => employee.Id);
            // Определяет что EmploeeId сущности должен быть уникальным.
            builder.HasIndex(employee => employee.Id).IsUnique();
            builder.HasMany(employee => employee.FactoryShift).WithOne(shift => shift.Employee);
        }
    }
}