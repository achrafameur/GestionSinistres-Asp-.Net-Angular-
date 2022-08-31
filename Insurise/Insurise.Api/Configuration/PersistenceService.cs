using Insurise.Infrastructure.Repositories;
using Insurise.SharedKernel.Interfaces;

namespace Insurise.Api.Configuration;

public static class PersistenceService
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>)); 
        return services;
    }
}
