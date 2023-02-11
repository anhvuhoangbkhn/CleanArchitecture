using Microsoft.Extensions.Configuration;

namespace Infrastructure.Common.Extensions.Configurations
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(
            this IConfiguration configuration)
        => configuration.GetConnectionString("DefaultConnection")!;
    }
}
