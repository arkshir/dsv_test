using MoviesApi.Core.MoviesAggregate;
using MoviesApi.UseCases.Movies;
using MoviesApi.UseCases.Movies.GetById;

using Riok.Mapperly.Abstractions;

namespace MoviesApi.Api.Endpoints.Movies.Get;

[Mapper]
public static partial class GetMovieMapper
{
    [UserMapping]
    public static GetMovieByIdQuery Map(GetMovieRequest request)
    {
        return new GetMovieByIdQuery(MovieId.From(request.Id));
    }

    public static partial GetMovieResponse Map(MovieDetailsDto movie);
}