using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartLab.Infrastructure.Data;
using SmartLab.Domain.Repositories;

namespace SmartLab.Infrastructure.StartupExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<SmartLabDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IAnimalRepository, AnimalRepository>();

        return services;
    }
}