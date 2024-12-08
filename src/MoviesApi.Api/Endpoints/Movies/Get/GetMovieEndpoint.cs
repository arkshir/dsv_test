using FastEndpoints;

using MoviesApi.Core.MoviesAggregate;
using MoviesApi.SharedKernel.Errors;
using MoviesApi.UseCases.Movies;
using MoviesApi.UseCases.Movies.GetById;

namespace MoviesApi.Api.Endpoints.Movies.Get;

public class GetMovieEndpoint : Endpoint<GetMovieRequest, GetMovieResponse>
{
    private readonly IMediator _mediator;

    public GetMovieEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Get("/movies/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetMovieRequest req, CancellationToken ct)
    {
        GetMovieByIdQuery query = GetMovieMapper.Map(req);

        GetMovieByIdResult result = await _mediator.Send(query, ct);

        if (result.TryPickT1(out EntityNotFound<Movie>? notFound, out MovieDetailsDto? movie))
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(GetMovieMapper.Map(movie), ct);
    }
}