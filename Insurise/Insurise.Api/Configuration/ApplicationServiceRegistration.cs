using Insurise.Application;
using MediatR;

namespace Insurise.Api.Configuration;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ApplicationClassesAssemblyHelper).Assembly);
        services.AddMediatR(typeof(ApplicationClassesAssemblyHelper).Assembly);
        return services;
    }
}