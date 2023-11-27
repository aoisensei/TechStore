using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Techstore.Application.Brand.Dto;
using Techstore.Application.Category.Dto;
using Techstore.Application.Interface;

namespace Techstore.Application
{
    public static class ConfigService
    {
        public static IServiceCollection AddTechStoreApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });
            services.AddScoped<IRepository<Domain.Entities.Brand>, BrandRepo>();
            services.AddScoped<IRepository<Domain.Entities.Category>, CategoryRepo>();

            return services;
        }
    }
}