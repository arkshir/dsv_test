namespace MoviesApi.SharedKernel.Errors;

public class EntityNotFound<T> where T : class
{
    private readonly object _key;

    public EntityNotFound(object key)
    {
        _key = key;
    }

    public string Message => $"An entity of type '{typeof(T).Name}' and Id '{_key}' was not found.";
}