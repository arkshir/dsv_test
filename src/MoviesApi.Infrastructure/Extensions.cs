using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MoviesApi.Infrastructure.Data;
using MoviesApi.Infrastructure.Data.Queries.Movies;
using MoviesApi.UseCases.Movies.GetById;
using MoviesApi.UseCases.Movies.List;

namespace MoviesApi.Infrastructure;

public static class Extensions
{
    public static T AddInfrastructure<T>(this T builder, bool isAspire) where T : IHostApplicationBuilder
    {
        builder.Services.AddSingleton(TimeProvider.System);

        if (isAspire)
        {
            builder.AddSqlServerDbContext<AppDbContext>("moviesdb");
        }

        builder.Services.AddScoped<IListMoviesQueryService, ListMoviesQueryService>();
        builder.Services.AddScoped<IGetMovieByIdQueryService, GetMovieByIdQueryService>();

        return builder;
    }
}