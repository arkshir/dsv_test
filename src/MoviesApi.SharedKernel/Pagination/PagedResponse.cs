namespace MoviesApi.SharedKernel.Pagination;

public class PagedResponse<T>
{
    public required IEnumerable<T> Items { get; init; }
    public required int TotalItems { get; init; }
    public required int Page { get; init; }
    public required int PageSize { get; init; }
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    public bool HasPrevious => Page > 1;
    public bool HasNext => Page < TotalPages;
}