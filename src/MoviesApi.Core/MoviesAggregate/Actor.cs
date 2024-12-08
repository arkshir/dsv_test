namespace MoviesApi.Core.MoviesAggregate;

public class Actor : EntityBase<ActorId>
{
    public required string Name { get; set; }
    public ICollection<Movie> Movies { get; set; } = [];
}

[ValueObject<int>(Conversions.SystemTextJson | Conversions.EfCoreValueConverter)]
public readonly partial struct ActorId;