using Gridify;

using MoviesApi.SharedKernel;

namespace MoviesApi.UseCases.Movies.List;

public class ListMoviesQuery : GridifyQuery, IQuery<ListMoviesResult>;