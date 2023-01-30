using HealthyHole.Application;
using HealthyHole.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthyHole.Dal
{
    /// <summary>
    /// Регестрируем необходимые сервисы DAL слоя.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddDal(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];

            services.AddDbContext<HealthyHoleDbContext>(options => { options.UseSqlite(connectionString); });
            services.AddScoped<IHealthyHoleDbContext>(provider => provider.GetService<HealthyHoleDbContext>());

            return services;
        }
    }
}