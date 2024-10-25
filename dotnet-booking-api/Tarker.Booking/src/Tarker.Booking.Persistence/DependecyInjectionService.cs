using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tarker.Booking.Persistence.Database;
using Tarker.Booking.Application.Database;
using Azure.Identity;
using Microsoft.Data.SqlClient.AlwaysEncrypted.AzureKeyVaultProvider;
using Microsoft.Data.SqlClient;
using Azure.Core;

namespace Tarker.Booking.Persistence
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseService>(options => options.UseSqlServer(configuration["SQLConnectionString"]));

            services.AddScoped<IDatabaseService, DatabaseService>();

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "local")
            {
                string tenantId = Environment.GetEnvironmentVariable("tenantId") ?? string.Empty;
                string clientId = Environment.GetEnvironmentVariable("clientId") ?? string.Empty;
                string clientSecret = Environment.GetEnvironmentVariable("clientSecret") ?? string.Empty;

                var tokenCredentials = new ClientSecretCredential(tenantId, clientId, clientSecret);

                var azureKeyVaultProvider = new SqlColumnEncryptionAzureKeyVaultProvider(tokenCredentials);

                SqlConnection.RegisterColumnEncryptionKeyStoreProviders(new Dictionary<string, SqlColumnEncryptionKeyStoreProvider>(1, StringComparer.OrdinalIgnoreCase)
                {
                    {
                        SqlColumnEncryptionAzureKeyVaultProvider.ProviderName, azureKeyVaultProvider
                    }
                });
            }
            else
            {
                var azureKeyVaultProvider = new SqlColumnEncryptionAzureKeyVaultProvider(new ManagedIdentityCredential());

                SqlConnection.RegisterColumnEncryptionKeyStoreProviders(new Dictionary<string, SqlColumnEncryptionKeyStoreProvider>(1, StringComparer.OrdinalIgnoreCase)
                {
                    {
                        SqlColumnEncryptionAzureKeyVaultProvider.ProviderName, azureKeyVaultProvider
                    }
                });
            }

            return services;
        }
    }
}
