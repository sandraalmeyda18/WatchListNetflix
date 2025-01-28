using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WatchListNetflix.Model.Entities;

namespace WatchListNetflix.Data.Configuration;

public class WatchListConfig : IEntityTypeConfiguration<Watchlist>
{
    public void Configure(EntityTypeBuilder<Watchlist> builder)
    {
        builder.HasOne<Client>().WithMany(x => x.WatchLists).HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Cascade);
    }
}
