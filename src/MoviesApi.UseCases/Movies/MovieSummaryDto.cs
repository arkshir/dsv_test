namespace MoviesApi.UseCases.Movies;

public record MovieSummaryDto(
    int Id,
    string ShowId,
    string Title,
    string Type,
    IEnumerable<string> Genres,
    string Rating,
    string Duration);