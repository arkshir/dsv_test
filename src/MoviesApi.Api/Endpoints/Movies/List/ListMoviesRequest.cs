using System.ComponentModel;

using FastEndpoints;

namespace MoviesApi.Api.Endpoints.Movies.List;

public sealed class ListMoviesRequest
{
    [QueryParam] [DefaultValue(1)] public int Page { get; set; } = 1;

    [QueryParam] [DefaultValue(20)] public int PageSize { get; set; } = 20;
    [QueryParam] [DefaultValue("id desc")] public string OrderBy { get; set; } = "id desc";
    [QueryParam] public string? Filter { get; set; }
}