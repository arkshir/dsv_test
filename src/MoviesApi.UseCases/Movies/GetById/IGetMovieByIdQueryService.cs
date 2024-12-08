using MoviesApi.Core.MoviesAggregate;

namespace MoviesApi.UseCases.Movies.GetById;

public interface IGetMovieByIdQueryService
{
    ValueTask<MovieDetailsDto?> GetByIdAsync(MovieId movieId, CancellationToken cancellationToken = default);
}