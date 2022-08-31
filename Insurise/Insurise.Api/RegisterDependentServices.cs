using Insurise.Api.Configuration;

namespace Insurise.Api;

public static class RegisterDependentServices
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddSession();
        services.AddPersistenceServices();
        services.AddApplicationServices();
        services.RegisterValidators();
        return services;
    }
}