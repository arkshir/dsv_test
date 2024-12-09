using FastEndpoints;
using FastEndpoints.Swagger;

using MoviesApi.Api.ExceptionHandlers;
using MoviesApi.Infrastructure;
using MoviesApi.UseCases;

using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add core services
builder.Services.AddUseCases();

builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(p =>
    {
        p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddExceptionHandler<ValidationExceptionHandler>();

string? isAspire = Environment.GetEnvironmentVariable("ASPNETCORE_ASPIRE");

// Add infrastructure services
builder.AddInfrastructure(isAspire == "1");

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add FastEndpoints
builder.Services.AddFastEndpoints();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.SwaggerDocument(o =>
{
    o.EnableJWTBearerAuth = false;
    o.DocumentSettings = s =>
    {
        s.Title = "Movies API";
        s.Version = "v1.0";
    };
});

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.UseCors();

app.UseFastEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen(o =>
    {
        o.Path = "openapi/{documentName}.json";
    });

    app.MapScalarApiReference(options =>
    {
        options.Theme = ScalarTheme.DeepSpace;
        options.Servers = [new ScalarServer("https://localhost:7445")];
    });
}

app.MapDefaultEndpoints();

await app.RunAsync();

public partial class Program;