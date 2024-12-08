using MoviesApi.SharedKernel.Pagination;
using MoviesApi.UseCases.Movies;
using MoviesApi.UseCases.Movies.List;

using Riok.Mapperly.Abstractions;

namespace MoviesApi.Api.Endpoints.Movies.List;

[Mapper]
public static partial class ListMoviesMapper
{
    public static partial ListMoviesQuery Map(ListMoviesRequest request);
    public static partial ListMoviesResponse Map(PagedResponse<MovieSummaryDto> response);
}