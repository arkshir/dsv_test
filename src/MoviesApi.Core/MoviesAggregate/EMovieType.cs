using System.ComponentModel;

namespace MoviesApi.Core.MoviesAggregate;

public enum EMovieType
{
    [Description("Movie")] Movie,
    [Description("TV Show")] TvShow
}