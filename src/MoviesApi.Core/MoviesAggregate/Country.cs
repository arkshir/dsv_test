namespace MoviesApi.Core.MoviesAggregate;

public class Country : EntityBase<CountryId>
{
    public required string Name { get; set; }
    public ICollection<Movie> Movies { get; set; } = [];
}

[ValueObject<int>(Conversions.SystemTextJson | Conversions.EfCoreValueConverter)]
public readonly partial struct CountryId;