namespace WatchListNetflix.Model.Entities;

public enum Category
{
    Suspense,
    Family,
    Action
}

public abstract class Audiovisual : BaseEntity
{
    public string Title { get; set; }

    public string Synopsis { get; set; }

    public DateTime ReleaseDate { get; set; }

    public Category Category { get; set; }

    public int WatchlistId { get; set; }
}
