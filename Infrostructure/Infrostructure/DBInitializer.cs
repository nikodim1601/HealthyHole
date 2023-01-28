using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure

{
    public class DBInitializer
    {
        public static void Initialize(HealthyHoleDBContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
