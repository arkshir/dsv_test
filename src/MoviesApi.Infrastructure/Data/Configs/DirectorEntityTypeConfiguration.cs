namespace MoviesApi.Infrastructure.Data.Configs;

public class DirectorEntityTypeConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.Property(x => x.Id).HasConversion(new DirectorId.EfCoreValueConverter()).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
    }
}