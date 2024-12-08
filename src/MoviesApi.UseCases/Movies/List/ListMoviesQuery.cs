using Gridify;

using MoviesApi.SharedKernel.Pagination;

namespace MoviesApi.Core.MoviesAggregate.Queries.ListMovies;

public class ListMoviesQuery : GridifyQuery, IQuery<ListMoviesResult>;