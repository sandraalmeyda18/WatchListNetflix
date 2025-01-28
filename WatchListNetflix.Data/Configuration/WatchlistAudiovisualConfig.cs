using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListNetflix.Model.Entities;

namespace WatchListNetflix.Data.Configuration;

public class WatchlistAudiovisualConfig : IEntityTypeConfiguration<WatchlistAudiovisual>
{
    public void Configure(EntityTypeBuilder<WatchlistAudiovisual> builder)
    {
        builder.HasOne(x => x.Watchlist)
            .WithMany(x => x.Audiovisuals)
            .HasForeignKey(x => x.WatchlistId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Audiovisual)
            .WithMany()
            .HasForeignKey(c => c.AudiovisualId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
