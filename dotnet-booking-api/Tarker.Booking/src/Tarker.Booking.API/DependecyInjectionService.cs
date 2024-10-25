using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Tarker.Booking.API
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services) {

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Tarker Booking API",
                    Description = "API Management for Booking App"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Ingrese un token válido",

                });
                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, fileName));
            });
            
            return services;
        }
    }
}
