using Insurise.Api;
using Insurise.Api.Configuration;
using Insurise.Api.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabase(builder.Configuration);
builder.Services.RegisterServices();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionMiddleware>();
});

builder.Services.AddCors(); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

var app = builder.Build();
app.Services.UseApplicationDatabase(app.Environment);

// Configure the HTTP request pipeline.
 
app.UseCors(options =>
    options.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders(new string[] { "X-Total-Count", "X-Pagination" }).AllowCredentials()
        );


app.SetupMiddleware();
app.UseSwagger();
app.Run();
