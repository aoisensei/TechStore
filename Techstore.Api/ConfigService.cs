using Techstore.Infrastructure;

namespace Techstore.Api
{
    public static class ConfigService
    {
        public static IServiceCollection AddTechStoreApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStr = configuration.GetConnectionString("default");
            services.AddTechStoreInfrastructureServices(connectionStr);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

    }
}
