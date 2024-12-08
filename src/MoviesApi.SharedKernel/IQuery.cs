namespace MoviesApi.SharedKernel;

public interface IQuery<out TResponse> : IRequest<TResponse>;