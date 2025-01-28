using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WatchListNetflix.Model.Entities;

namespace WatchListNetflix.Data;

public class WatchListNetflixContext : DbContext
{
    public WatchListNetflixContext(DbContextOptions<WatchListNetflixContext> options) : base(options)
    {
    }

    public DbSet<User> Users {  get; set; }
    
    public DbSet<Client> Clients { get; set; }

    public DbSet<Audiovisual> Audiovisuals { get; set; }

    public DbSet<Watchlist> Watchlists { get; set; }

    public DbSet<WatchlistAudiovisual> WatchlistAudiovisuals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
           .Entries()
           .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var entity = (BaseEntity)entry.Entity;

            // If it is a new record, set the creation date
            if (entry.State == EntityState.Added)
            {
                entity.CreatedAt = DateTime.Now;
            }

            // Always update the update date
            entity.UpdatedAt = DateTime.UtcNow;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
