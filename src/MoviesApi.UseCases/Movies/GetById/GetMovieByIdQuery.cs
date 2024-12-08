using MoviesApi.Core.MoviesAggregate;
using MoviesApi.SharedKernel;

namespace MoviesApi.UseCases.Movies.GetById;

public record GetMovieByIdQuery(MovieId MovieId) : IQuery<GetMovieByIdResult>;