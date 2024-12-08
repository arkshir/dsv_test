namespace MoviesApi.Core.MoviesAggregate;

public class Director : EntityBase<DirectorId>
{
    public required string Name { get; set; }
    public ICollection<Movie> Movies { get; set; } = [];
}

[ValueObject<int>(Conversions.SystemTextJson | Conversions.EfCoreValueConverter)]
public readonly partial struct DirectorId;