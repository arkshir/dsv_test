using MoviesApi.SharedKernel.Pagination;
using MoviesApi.UseCases.Movies;

namespace MoviesApi.Api.Endpoints.Movies.List;

public class ListMoviesResponse : PagedResponse<MovieSummaryDto>;