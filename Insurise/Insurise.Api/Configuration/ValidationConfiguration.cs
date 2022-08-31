using FluentValidation.AspNetCore;
using Insurise.Api.Validation;

namespace Insurise.Api.Configuration;

public static class ValidationConfiguration
{
    public static IServiceCollection RegisterValidators(this IServiceCollection services)
    {
        services.AddFluentValidation(fv =>
            fv.RegisterValidatorsFromAssembly(typeof(CreateBranchCommandValidator).Assembly));
        return services;
    }
}