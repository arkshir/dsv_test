namespace MoviesApi.SharedKernel;

public abstract class EntityBase<TId> where TId : struct, IEquatable<TId>
{
    public TId Id { get; set; } = default!;
}