namespace MoviesApi.Infrastructure.Data.Configs;

public class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(x => x.Id).HasConversion(new CountryId.EfCoreValueConverter()).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
    }
}