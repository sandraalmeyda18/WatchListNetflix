namespace WatchListNetflix.Model.Entities;

public class Watchlist : BaseEntity
{
    public string Name { get; set; }

    public int ClientId { get; set; }

    public ICollection<Audiovisual> Audiovisuals { get; set; }
}
