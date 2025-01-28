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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
