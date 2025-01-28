using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WatchListNetflix.Model.Entities;

namespace WatchListNetflix.Data.Configuration;

public class AudiovisualConfig : IEntityTypeConfiguration<Audiovisual>
{
    public void Configure(EntityTypeBuilder<Audiovisual> builder)
    {
        builder.HasDiscriminator<string>("AudiovisualType")
            .HasValue<Movie>(nameof(Movie))
            .HasValue<Serie>(nameof(Serie));
    }
}
