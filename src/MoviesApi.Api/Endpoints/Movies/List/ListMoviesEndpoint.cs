using FastEndpoints;

namespace MoviesApi.Api.Endpoints.Movies.List;

[UsedImplicitly]
public class ListMoviesEndpoint : EndpointWithoutRequest<ListMoviesResponse>
{
    private readonly IMediator _mediator;

    public ListMoviesEndpoint(IMediator mediator)
    {
        _mediator = mediator;
        // CDFDZDX9dS
    }

    public override void Configure()
    {
        Verbs(Http.GET);
        Get("movies");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendOkAsync(ct);
    }
}