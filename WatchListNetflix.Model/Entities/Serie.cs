namespace WatchListNetflix.Model.Entities;

public class Serie : Audiovisual
{
    /// <summary>
    /// Duration (minutes)
    /// </summary>
    public int Duration { get; set; }

    public string Director { get; set; }
}
