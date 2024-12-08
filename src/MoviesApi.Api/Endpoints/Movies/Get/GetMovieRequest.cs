using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Api.Endpoints.Movies.Get;

public class GetMovieEndpointRequest
{
    [Required] public int Id { get; set; }
}