using Insurise.Infrastructure.Data;
using Insurise.Infrastructure.Repositories;
using Insurise.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Insurise.Infrastructure;

public static class PersistenceService
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly("Insurise.Infrastructure")));

        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));


        return services;
    }
}