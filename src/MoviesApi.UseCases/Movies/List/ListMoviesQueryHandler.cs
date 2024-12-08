using MoviesApi.SharedKernel;

namespace MoviesApi.UseCases.Movies.List;

public class ListMoviesQueryHandler : IQueryHandler<ListMoviesQuery, ListMoviesResult>
{
    private readonly IListMoviesQueryService _listMoviesQueryService;

    public ListMoviesQueryHandler(IListMoviesQueryService listMoviesQueryService)
    {
        _listMoviesQueryService = listMoviesQueryService;
    }

    public async Task<ListMoviesResult> Handle(ListMoviesQuery request, CancellationToken cancellationToken)
    {
        return await _listMoviesQueryService.ListAsync(request, cancellationToken);
    }
}