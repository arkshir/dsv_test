using System.ComponentModel;

namespace MoviesApi.Core.MoviesAggregate;

public enum EMovieRating
{
    [Description("G")] G,
    [Description("NC-17")] NC17,
    [Description("NR")] NR,
    [Description("PG")] PG,
    [Description("PG-13")] PG13,
    [Description("R")] R,
    [Description("TV-14")] TV14,
    [Description("TV-G")] TVG,
    [Description("TV-MA")] TVMA,
    [Description("TV-PG")] TVPG,
    [Description("TV-Y")] TVY,
    [Description("TV-Y7")] TVY7,
    [Description("TV-Y7-FV")] TVY7FV,
    [Description("UR")] UR
}