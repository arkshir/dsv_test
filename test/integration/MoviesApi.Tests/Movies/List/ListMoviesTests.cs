using MoviesApi.Api.Endpoints.Movies.List;

namespace MoviesApi.Tests.Movies.List;

[Collection(RootCollection.Name)]
public class ListMoviesTests : TestBase
{
    private readonly App _app;

    public ListMoviesTests(App app)
    {
        _app = app;
    }

    [Fact]
    [Priority(1)]
    public async Task ListMovies_OnValidRequest_ShouldReturnListOfMovies()
    {
        (HttpResponseMessage rsp, ListMoviesResponse res) =
            await _app.Client.GETAsync<ListMoviesEndpoint, ListMoviesRequest, ListMoviesResponse>(
                new ListMoviesRequest());

        rsp.StatusCode.Should().Be(HttpStatusCode.OK);
        res.Items.Should().NotBeEmpty();
    }

    [Fact]
    [Priority(2)]
    public async Task ListMovies_OnInvalidRequest_ShouldReturnUnprocessableEntity()
    {
        (HttpResponseMessage rsp, ListMoviesResponse res) =
            await _app.Client.GETAsync<ListMoviesEndpoint, ListMoviesRequest, ListMoviesResponse>(
                new ListMoviesRequest { PageSize = 100 });

        rsp.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
    }
}