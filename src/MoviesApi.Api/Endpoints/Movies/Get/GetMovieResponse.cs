using MoviesApi.Core.MoviesAggregate;
using MoviesApi.SharedKernel.Dtos;
using MoviesApi.UseCases.Movies;

namespace MoviesApi.Api.Endpoints.Movies.Get;

public record GetMovieResponse(
    MovieId Id,
    string ShowId,
    string Title,
    string Type,
    IEnumerable<LookupDto> Directors,
    IEnumerable<LookupDto> Cast,
    IEnumerable<LookupDto> Countries,
    DateOnly DateAdded,
    int ReleaseYear,
    string Rating,
    string Duration,
    IEnumerable<LookupDto> Genres,
    string Description) : MovieDetailsDto(Id, ShowId, Title, Type, Directors, Cast, Countries, DateAdded, ReleaseYear,
    Rating, Duration, Genres, Description);