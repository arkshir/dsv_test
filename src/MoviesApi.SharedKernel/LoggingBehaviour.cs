using System.Diagnostics;
using System.Reflection;

using Microsoft.Extensions.Logging;

namespace MoviesApi.SharedKernel;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<Mediator> _logger;

    public LoggingBehaviour(ILogger<Mediator> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("Handling {RequestName}", typeof(TRequest).Name);

            // Reflection! Could be a performance concern
            Type myType = request.GetType();
            PropertyInfo[] props = myType.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object? propValue = prop.GetValue(request, null);
                _logger.LogDebug("Property {Property} : {@Value}", prop.Name, propValue);
            }
        }

        long start = Stopwatch.GetTimestamp();

        TResponse response = await next();

        TimeSpan elapsed = Stopwatch.GetElapsedTime(start);

        _logger.LogInformation("Handled {RequestName} with {Response} in {ms} ms", typeof(TRequest).Name, response,
            elapsed.Milliseconds);

        return response;
    }
}