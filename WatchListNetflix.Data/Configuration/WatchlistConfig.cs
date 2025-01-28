using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WatchListNetflix.Model.Entities;

namespace WatchListNetflix.Data.Configuration;

public class WatchListConfig : IEntityTypeConfiguration<Watchlist>
{
    public void Configure(EntityTypeBuilder<Watchlist> builder)
    {
    }
}
