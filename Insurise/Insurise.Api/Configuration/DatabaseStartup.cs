using Insurise.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Insurise.Api.Configuration;

public static class DatabaseConfiguration
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = null;
        var databaseUrl = configuration.GetValue<string>("DATABASE_URL");

        if (!string.IsNullOrEmpty(databaseUrl) &&
            Uri.IsWellFormedUriString(databaseUrl, UriKind.RelativeOrAbsolute))
        {
            Console.WriteLine("DATABASE_URL will be used to create the connection string.");
            //  Parse the connection string
            var databaseUri = new Uri(databaseUrl);
            var db = databaseUri.LocalPath.TrimStart('/');
            var userInfo = databaseUri.UserInfo.Split(':', StringSplitOptions.RemoveEmptyEntries);

            switch (databaseUri.Scheme)
            {
                case "postgres":
                    connectionString =
                        $"Server={databaseUri.Host};Port={databaseUri.Port};Database={db};User Id={userInfo[0]};Password={userInfo[1]};Integrated Security=true;Pooling=true;MinPoolSize=0;MaxPoolSize=20;";
                    break;
                case "mysql":
                    connectionString =
                        $"Server={databaseUri.Host};Port={databaseUri.Port};Database={db};User={userInfo[0]};Password={userInfo[1]};Pooling=true;MinimumPoolSize=0;MaximumPoolsize=10;";
                    break;
                case "mssql":
                    connectionString =
                        $"Server={databaseUri.Host};Port={databaseUri.Port};Database={db};User={userInfo[0]};Password={userInfo[1]};Trusted_Connection=False;Pooling=true;";
                    break;
                case "mongodb":
                    connectionString =
                        $"Server={databaseUri.Host};Port={databaseUri.Port};Database={db};User={userInfo[0]};Password={userInfo[1]};Pooling=true;MinimumPoolSize=0;MaximumPoolsize=10;";
                    break;
                default:
                    Console.WriteLine(
                        "It was not possible to determine the database type provided by DATABASE_URL");
                    break;
            }
        }
        else
        {
            connectionString = configuration.GetConnectionString("insuriseDb");
        }

        services.AddDbContext<AppDbContext>(options =>
        {
            if (connectionString != null)
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Insurise.Infrastructure"));
        });
        services.AddScoped<DbContext>(provider =>
            provider.GetService<AppDbContext>() ?? throw new InvalidOperationException());

        return services;
    }

    public static void UseApplicationDatabase(this IServiceProvider serviceProvider, IHostEnvironment environment)
    {
        if (environment.EnvironmentName.Equals("Achref") || environment.IsDevelopment() || environment.IsProduction())
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
        }
    }
}
