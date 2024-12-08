namespace MoviesApi.Infrastructure.Data.Configs;

public class ActorEntityTypeConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.Property(x => x.Id).HasConversion(new ActorId.EfCoreValueConverter()).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
    }
}