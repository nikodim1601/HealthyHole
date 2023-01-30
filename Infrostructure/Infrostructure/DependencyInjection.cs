using Application;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyHole.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDal(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];

            services.AddDbContext<HealthyHoleDBContext>(options => { options.UseSqlite(connectionString); });
            services.AddScoped<IHealthyHoleDBContext>(provider => provider.GetService<HealthyHoleDBContext>());

            return services;
        }
    }
}