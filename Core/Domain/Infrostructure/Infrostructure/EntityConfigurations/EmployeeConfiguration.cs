using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Определяет что является ключем записи.
            builder.HasKey(factoryChange => factoryChange.Id);
            // Определяет что EmploeeId сущности должен быть уникальным.
            builder.HasIndex(factoryChange => factoryChange.Id).IsUnique();
        }
    }
}
