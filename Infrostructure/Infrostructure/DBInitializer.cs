using System;
using System.Collections.Generic;
using System.Linq;
using HealthyHole.Domain;

namespace HealthyHole.Dal
{
    public static class DbInitializer
    {
        public static void Initialize(HealthyHoleDbContext context)
        {
            context.Database.EnsureCreated();
            UserInjection(context);
        }

        /// <summary>
        /// Добавляет немножко тестовых пользователей.
        /// </summary>
        private static void UserInjection(HealthyHoleDbContext context)
        {
            if (context.Employees.Any())
            {
                return;
            }
            
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Position = Constants.Positions.Engineer,
                FirstName = "Руслан",
                SecondName = "Альтиджиев",
                SureName = "Петров",
                FactoryShift = new List<FactoryShift>()
            });
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Position = Constants.Positions.Engineer,
                FirstName = "Ядвига",
                SecondName = "Палловна",
                SureName = "Аркадьевна",
                FactoryShift = new List<FactoryShift>()
            });
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Position = Constants.Positions.Master,
                FirstName = "Билли",
                SecondName = "Херингтон",
                SureName = "Уильям Глен Гарольдов",
                FactoryShift = new List<FactoryShift>()
            });
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Position = Constants.Positions.TesterOfCUMdle,
                FirstName = "Ван",
                SecondName = "Даркхолм",
                SureName = "Иванов",
                FactoryShift = new List<FactoryShift>()
            });
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Position = Constants.Positions.TesterOfCUMdle,
                FirstName = "Фис",
                SecondName = "Тинг",
                SureName = "Фрихандридбаксов",
                FactoryShift = new List<FactoryShift>()
            });

            context.SaveChanges();
        }
    }
}