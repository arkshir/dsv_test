using MoviesApi.Core.MoviesAggregate;
using MoviesApi.SharedKernel;
using MoviesApi.SharedKernel.Dtos;

using Riok.Mapperly.Abstractions;

namespace MoviesApi.UseCases.Movies;

[Mapper]
public static partial class MoviesMapper
{
    public static partial IQueryable<MovieDetailsDto> ProjectToDetailsDto(this IQueryable<Movie> queryable);
    public static partial IQueryable<MovieSummaryDto> ProjectToSummaryDto(this IQueryable<Movie> queryable);

    [MapperIgnoreSource(nameof(Movie.Directors))]
    [MapperIgnoreSource(nameof(Movie.Cast))]
    [MapperIgnoreSource(nameof(Movie.Countries))]
    [MapperIgnoreSource(nameof(Movie.DateAdded))]
    [MapperIgnoreSource(nameof(Movie.ReleaseYear))]
    [MapperIgnoreSource(nameof(Movie.Description))]
    [MapProperty(nameof(Movie.Categories), nameof(MovieSummaryDto.Genres))]
    public static partial MovieSummaryDto MapToSummary(Movie movie);

    [MapProperty(nameof(Movie.Categories), nameof(MovieDetailsDto.Genres))]
    public static partial MovieDetailsDto MapToDetails(Movie movie);

    [UserMapping]
    public static string Map(Category category)
    {
        return category.Name;
    }

    [UserMapping]
    public static string Map(EMovieRating rating)
    {
        return rating.GetDescription();
    }

    [UserMapping]
    public static string Map(EMovieType movieType)
    {
        return movieType.GetDescription();
    }

    [MapperIgnoreSource(nameof(Director.Movies))]
    public static partial LookupDto MapToLookup(Director director);

    [MapperIgnoreSource(nameof(Actor.Movies))]
    public static partial LookupDto MapToLookup(Actor actor);

    [MapperIgnoreSource(nameof(Category.Movies))]
    public static partial LookupDto MapToLookup(Category category);

    [MapperIgnoreSource(nameof(Country.Movies))]
    public static partial LookupDto MapToLookup(Country actor);
}