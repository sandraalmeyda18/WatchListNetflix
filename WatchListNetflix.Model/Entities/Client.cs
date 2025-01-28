namespace WatchListNetflix.Model.Entities;

public class Client : BaseEntity
{
    public int UserId { get; set; }

    public User User { get; set; }

    public ICollection<Watchlist> WatchLists { get; set; }
}
