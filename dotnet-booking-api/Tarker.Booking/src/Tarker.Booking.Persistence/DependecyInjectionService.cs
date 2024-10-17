using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tarker.Booking.Persistence.Database;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Persistence
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseService>(options => options.UseSqlServer(configuration["SQLConnectionString"]));

            services.AddScoped<IDatabaseService, DatabaseService>();

            return services;
        }
    }
}
