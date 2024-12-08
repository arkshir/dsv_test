using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Api.Endpoints.Movies.Get;

public class GetMovieRequest
{
    [Required] public required int Id { get; set; }
}