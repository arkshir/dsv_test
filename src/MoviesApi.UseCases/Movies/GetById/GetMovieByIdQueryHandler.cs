using MoviesApi.Core.MoviesAggregate;
using MoviesApi.SharedKernel;
using MoviesApi.SharedKernel.Errors;

namespace MoviesApi.UseCases.Movies.GetById;

public class GetMovieByIdQueryHandler : IQueryHandler<GetMovieByIdQuery, GetMovieByIdResult>
{
    private readonly IGetMovieByIdQueryService _getMovieByIdQueryService;

    public GetMovieByIdQueryHandler(IGetMovieByIdQueryService getMovieByIdQueryService)
    {
        _getMovieByIdQueryService = getMovieByIdQueryService;
    }

    public async Task<GetMovieByIdResult> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        MovieDetailsDto? movie = await _getMovieByIdQueryService.GetByIdAsync(request.MovieId, cancellationToken);

        if (movie is null)
        {
            return new EntityNotFound<Movie>(request.MovieId);
        }

        return movie;
    }
}