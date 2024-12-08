using MoviesApi.Core.MoviesAggregate;
using MoviesApi.SharedKernel.Errors;

using OneOf;

namespace MoviesApi.UseCases.Movies.GetById;

[GenerateOneOf]
public partial class GetMovieByIdResult : OneOfBase<MovieDetailsDto, EntityNotFound<Movie>>;