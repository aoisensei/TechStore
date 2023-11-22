using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techstore.Infrastructure.Data;
using System.Reflection;

namespace Techstore.Infrastructure;

public static class ConfigService
{
    public static IServiceCollection AddTechStoreInfrastructureServices(this IServiceCollection services, string connectionStr)
    {
        services.AddDbContext<TechStoreDbContext>(builder => builder.UseSqlServer(connectionStr, sql => sql.MigrationsAssembly("Techstore.Api")));

        return services;
    }
}
