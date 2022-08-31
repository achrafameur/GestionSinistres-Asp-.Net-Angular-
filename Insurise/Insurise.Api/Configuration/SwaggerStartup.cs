using Microsoft.OpenApi.Models;

namespace Insurise.Api.Configuration;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v2", new OpenApiInfo {Title = "Insurise API", Version = "0.0.1"});
        });

        return services;
    }

    public static IApplicationBuilder UseSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger(c => { c.RouteTemplate = "{documentName}/api-docs"; });
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/v2/api-docs", "Insurise API"); });
        return app;
    }
}
