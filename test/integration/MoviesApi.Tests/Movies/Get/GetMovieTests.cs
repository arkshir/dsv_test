using MoviesApi.Api.Endpoints.Movies.Get;
using MoviesApi.Core.MoviesAggregate;

namespace MoviesApi.Tests.Movies.Get;

[Collection(RootCollection.Name)]
public class GetMovieTests : TestBase
{
    private readonly App _app;

    public GetMovieTests(App app)
    {
        _app = app;
    }

    [Fact]
    [Priority(1)]
    public async Task GetMovie_OnValidRequest_ShouldReturnMovie()
    {
        const int id = 1;
        var movieId = MovieId.From(id);
        
        (HttpResponseMessage rsp, GetMovieResponse res) =
            await _app.Client.GETAsync<GetMovieEndpoint, GetMovieRequest, GetMovieResponse>(
                new GetMovieRequest
                {
                    Id = id
                });

        rsp.StatusCode.Should().Be(HttpStatusCode.OK);
        res.Id.Should().Be(movieId);
    }
    
    [Fact]
    [Priority(2)]
    public async Task GetMovie_OnInvalidRequest_ShouldReturnMovie()
    {
        const int id = 2;
        
        (HttpResponseMessage rsp, GetMovieResponse res) =
            await _app.Client.GETAsync<GetMovieEndpoint, GetMovieRequest, GetMovieResponse>(
                new GetMovieRequest
                {
                    Id = id
                });

        rsp.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}