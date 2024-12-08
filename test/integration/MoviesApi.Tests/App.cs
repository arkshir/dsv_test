using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

using MoviesApi.Core.MoviesAggregate;
using MoviesApi.Infrastructure.Data;

namespace MoviesApi.Tests;

public class App : AppFixture<Program>
{
    protected override async Task SetupAsync()
    {
        // place one-time setup for the fixture here
        var db = Services.GetRequiredService<AppDbContext>();
        
        await db.Movies.AddAsync(new Movie
        {
            Id = MovieId.From(1),
            ShowId = "s1",
            Title = "Star Wars: Episode IV - A New Hope",
            Description =
                "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.",
            Duration = "121 min",
            Type = EMovieType.Movie,
            DateAdded = DateOnly.FromDateTime(DateTime.Now),
            ReleaseYear = 1977,
            Rating = EMovieRating.PG,
            Directors =
            [
                new Director { Id = DirectorId.From(1), Name = "George Lucas" }
            ],
            Categories =
            [
                new Category { Id = CategoryId.From(1), Name = "Science Fiction" }
            ],
            Cast = 
            [
                new Actor { Id = ActorId.From(1), Name = "Mark Hamill" }
            ],
            Countries = 
            [
                new Country { Id = CountryId.From(1), Name = "United States" }
            ]
        });
        
        await db.SaveChangesAsync();
    }

    protected override void ConfigureApp(IWebHostBuilder a)
    {
        // do host builder configuration here
    }

    protected override void ConfigureServices(IServiceCollection s)
    {
        s.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("moviesdb"), ServiceLifetime.Transient);
        // do test service registration here
    }

    protected override Task TearDownAsync()
    {
        // do cleanups here
        return Task.CompletedTask;
    }
}