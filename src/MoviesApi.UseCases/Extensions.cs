using System.Reflection;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

using MoviesApi.SharedKernel;

namespace MoviesApi.UseCases;

public static class Extensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        Assembly? assembly = typeof(Extensions).Assembly;

        services.AddValidatorsFromAssembly(assembly);

        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssemblies(assembly, typeof(ValidationBehaviour<,>).Assembly);
            c.AddOpenBehavior(typeof(LoggingBehaviour<,>));
            c.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        return services;
    }
}