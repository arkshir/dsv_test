namespace MoviesApi.Core.MoviesAggregate;

public class Category : EntityBase<CategoryId>
{
    public required string Name { get; set; }
    public ICollection<Movie> Movies { get; set; } = [];
}

[ValueObject<int>(Conversions.SystemTextJson | Conversions.EfCoreValueConverter)]
public readonly partial struct CategoryId;