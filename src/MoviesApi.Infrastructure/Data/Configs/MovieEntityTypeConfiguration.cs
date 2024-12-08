namespace MoviesApi.Infrastructure.Data.Configs;

public class MovieEntityTypeConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Property(x => x.Id).HasConversion(new MovieId.EfCoreValueConverter()).ValueGeneratedOnAdd();
        builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();

        builder
            .HasMany(x => x.Cast)
            .WithMany(x => x.Movies)
            .UsingEntity<Dictionary<string, object>>(
                l => l.HasOne<Actor>().WithMany().HasForeignKey("ActorId"),
                r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                j => j.ToTable("MovieActors")
            );

        builder
            .HasMany(x => x.Categories)
            .WithMany(x => x.Movies)
            .UsingEntity<Dictionary<string, object>>(
                l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
                r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                j => j.ToTable("MovieCategories")
            );

        builder
            .HasMany(x => x.Directors)
            .WithMany(x => x.Movies)
            .UsingEntity<Dictionary<string, object>>(
                l => l.HasOne<Director>().WithMany().HasForeignKey("DirectorId"),
                r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                j => j.ToTable("MovieDirectors")
            );

        builder
            .HasMany(x => x.Countries)
            .WithMany(x => x.Movies)
            .UsingEntity<Dictionary<string, object>>(
                l => l.HasOne<Country>().WithMany().HasForeignKey("CountryId"),
                r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                j => j.ToTable("MovieCountries")
            );
    }
}