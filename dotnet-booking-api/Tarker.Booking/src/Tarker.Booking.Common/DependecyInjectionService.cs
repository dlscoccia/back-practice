using Microsoft.Extensions.DependencyInjection;

namespace Tarker.Booking.Common
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            return services;
        }
    }
}
