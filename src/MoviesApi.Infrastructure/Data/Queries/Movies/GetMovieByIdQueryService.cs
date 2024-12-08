using MoviesApi.UseCases.Movies;
using MoviesApi.UseCases.Movies.GetById;

namespace MoviesApi.Infrastructure.Data.Queries.Movies;

public class GetMovieByIdQueryService : IGetMovieByIdQueryService
{
    private readonly AppDbContext _db;

    public GetMovieByIdQueryService(AppDbContext db)
    {
        _db = db;
    }

    public async ValueTask<MovieDetailsDto?> GetByIdAsync(MovieId movieId,
        CancellationToken cancellationToken = default)
    {
        MovieDetailsDto? movie = await _db
            .Movies
            .AsNoTracking()
            .AsSplitQuery()
            .Where(m => m.Id == movieId)
            .ProjectToDetailsDto()
            .FirstOrDefaultAsync(cancellationToken);

        return movie;
    }
}