using Insurise.Infrastructure.Configurations;
using Microsoft.AspNetCore.Cors.Infrastructure; 
using Microsoft.Extensions.Options; 

namespace Insurise.Api.Configuration
{
    public static class SecurityStartup
    { 

        public static IServiceCollection AddSecurityModule(this IServiceCollection services)
        {
            //TODO Retrieve the signing key properly (DRY with TokenProvider)
            var opt = services.BuildServiceProvider().GetRequiredService<IOptions<SecuritySettings>>();
            var securitySettings = opt.Value; 
            return services;
        }

        public static IApplicationBuilder UseApplicationSecurity(this IApplicationBuilder app,
            SecuritySettings securitySettings)
        {
            app.UseCors(CorsPolicyBuilder(securitySettings.Cors));
            app.UseAuthentication();
            if (securitySettings.EnforceHttps)
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }
            return app;
        }

        private static Action<CorsPolicyBuilder> CorsPolicyBuilder(Cors config)
        {
            //TODO implement an url based cors policy rather than global or per controller
            return builder =>
            {
                if (!config.AllowedOrigins.Equals("*"))
                {
                    if (config.AllowCredentials)
                    {
                        builder.AllowCredentials();
                    }
                    else
                    {
                        builder.DisallowCredentials();
                    }
                }

                builder.WithOrigins(config.AllowedOrigins)
                    .WithMethods(config.AllowedMethods)
                    .WithHeaders(config.AllowedHeaders)
                    .WithExposedHeaders(config.ExposedHeaders)
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(config.MaxAge));
            };
        }
    }
}
