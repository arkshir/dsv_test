using Gridify;
using Gridify.EntityFramework;

using MoviesApi.SharedKernel.Pagination;
using MoviesApi.SharedKernel.Querying;
using MoviesApi.UseCases.Movies;
using MoviesApi.UseCases.Movies.List;

namespace MoviesApi.Infrastructure.Data.Queries.Movies;

public class ListMoviesQueryService : IListMoviesQueryService
{
    private static readonly IGridifyMapper<Movie> Mapper = new GridifyMapper<Movie>()
        .GenerateMappings()
        .RemoveMap(nameof(Movie.Id))
        .AddMap("id", p => p.Id, val => MovieId.From(Convert.ToInt32(val)));

    private readonly AppDbContext _db;

    public ListMoviesQueryService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<ListMoviesResult> ListAsync(ListMoviesQuery query, CancellationToken cancellationToken = default)
    {
        if (!query.IsValid<Movie>())
        {
            return new InvalidQueryParameters();
        }

        QueryablePaging<Movie>? queryable =
            await _db.Movies.AsNoTracking().GridifyQueryableAsync(query, Mapper, cancellationToken);

        PagedResponse<MovieSummaryDto>? result = new()
        {
            Items = queryable.Query.ProjectToSummaryDto(),
            Page = query.Page,
            PageSize = query.PageSize,
            TotalItems = queryable.Count
        };

        return result;
    }
}