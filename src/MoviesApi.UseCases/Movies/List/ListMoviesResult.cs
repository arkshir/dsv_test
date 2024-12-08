using MoviesApi.SharedKernel.Pagination;
using MoviesApi.SharedKernel.Querying;

using OneOf;

namespace MoviesApi.UseCases.Movies.List;

[GenerateOneOf]
public partial class ListMoviesResult : OneOfBase<PagedResponse<MovieSummaryDto>, InvalidQueryParameters>;