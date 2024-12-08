namespace MoviesApi.UseCases.Movies.List;

public interface IListMoviesQueryService
{
    Task<ListMoviesResult> ListAsync(ListMoviesQuery query, CancellationToken cancellationToken = default);
}