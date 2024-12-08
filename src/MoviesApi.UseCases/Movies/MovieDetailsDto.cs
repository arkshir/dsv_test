using MoviesApi.Core.MoviesAggregate;
using MoviesApi.SharedKernel.Dtos;

namespace MoviesApi.UseCases.Movies;

public record MovieDetailsDto(
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
    string Description
);