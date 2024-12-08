namespace MoviesApi.Core.MoviesAggregate.Dtos;

public record MovieSummaryDto(
    int Id,
    string ShowId,
    string Title,
    IEnumerable<string> Genres,
    string Rating,
    string Duration);