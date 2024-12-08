namespace MoviesApi.SharedKernel;

public interface ICommand<out TResponse> : IRequest<TResponse>;