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

        builder.HasOne<Watchlist>().WithMany(x => x.Audiovisuals).HasForeignKey(x => x.WatchlistId).OnDelete(DeleteBehavior.Cascade);
    }
}
