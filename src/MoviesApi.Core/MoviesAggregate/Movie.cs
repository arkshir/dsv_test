namespace MoviesApi.Core.MoviesAggregate;

public class Movie : EntityBase<MovieId>
{
    public required string ShowId { get; set; }
    public required EMovieType Type { get; set; }
    public required string Title { get; set; }
    public ICollection<Director> Directors { get; set; } = [];
    public ICollection<Actor> Cast { get; set; } = [];
    public ICollection<Country> Countries { get; set; } = [];
    public DateOnly? DateAdded { get; set; }
    public int ReleaseYear { get; set; }
    public EMovieRating Rating { get; set; }
    public required string Duration { get; set; }
    public ICollection<Category> Categories { get; set; } = [];
    public required string Description { get; set; }
}

[ValueObject<int>(Conversions.SystemTextJson | Conversions.EfCoreValueConverter)]
public readonly partial struct MovieId;