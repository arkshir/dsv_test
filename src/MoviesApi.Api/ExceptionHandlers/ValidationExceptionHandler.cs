using FluentValidation;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MoviesApi.Api.ExceptionHandlers;

public class ValidationExceptionHandler : IExceptionHandler
{
    private readonly ILogger<ValidationExceptionHandler> _logger;
    private readonly IProblemDetailsService _problemDetailsService;

    public ValidationExceptionHandler(
        IProblemDetailsService problemDetailsService,
        ILogger<ValidationExceptionHandler> logger
    )
    {
        _problemDetailsService = problemDetailsService;
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
        {
            return false;
        }

        _logger.LogDebug("One or more validation errors ocurred. {@ValidationException}", validationException);

        Dictionary<string, string[]>? validationErrors = validationException.Errors.GroupBy(x => x.PropertyName)
            .ToDictionary(x => x.Key, x => x.Select(y => y.ErrorMessage).ToArray());

        ValidationProblemDetails? problemDetails = new(validationErrors)
        {
            Status = StatusCodes.Status422UnprocessableEntity
        };

        ProblemDetailsContext? problemDetailsContext = new()
        {
            HttpContext = httpContext, Exception = validationException, ProblemDetails = problemDetails
        };

        httpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;

        await _problemDetailsService.WriteAsync(problemDetailsContext);

        return true;
    }
}