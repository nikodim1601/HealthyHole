using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Infrastructure;

namespace HealthyHole.Dal
{
    public static class DbInitializer
    {
        public static void Initialize(HealthyHoleDBContext context)
        {
            context.Database.EnsureCreated();
            UserInjection(context);
        }

        /// <summary>
        /// Добавляет немножко тестовых пользователей.
        /// </summary>
        private static void UserInjection(HealthyHoleDBContext context)
        {
            if (context.Employees.Any())
            {
                return;
            }
            
            var user = context.Employees.Add(new Employee()
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