namespace MoviesApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Actor> Actors => Set<Actor>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Director> Directors => Set<Director>();
    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}