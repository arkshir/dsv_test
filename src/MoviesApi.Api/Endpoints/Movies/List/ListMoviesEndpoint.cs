using FastEndpoints;

using MoviesApi.SharedKernel.Pagination;
using MoviesApi.SharedKernel.Querying;
using MoviesApi.UseCases.Movies;
using MoviesApi.UseCases.Movies.List;

namespace MoviesApi.Api.Endpoints.Movies.List;

[UsedImplicitly]
public class ListMoviesEndpoint : Endpoint<ListMoviesRequest, ListMoviesResponse>
{
    private readonly IMediator _mediator;

    public ListMoviesEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Get("movies");
        AllowAnonymous();
        Description(b => b
            .Produces(StatusCodes.Status422UnprocessableEntity)
            .ProducesProblemDetails()
        );
    }

    public override async Task HandleAsync(ListMoviesRequest req, CancellationToken ct)
    {
        ListMoviesQuery query = ListMoviesMapper.Map(req);

        ListMoviesResult result = await _mediator.Send(query, ct);

        if (result.TryPickT1(out InvalidQueryParameters invalidQueryParameters,
                out PagedResponse<MovieSummaryDto>? movies))
        {
            await SendResultAsync(TypedResults.UnprocessableEntity());
            return;
        }

        await SendOkAsync(ListMoviesMapper.Map(movies), ct);
    }
}