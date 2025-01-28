namespace WatchListNetflix.Services.Audiovisuals.Models;

public class MovieDto : AudiovisualDto
{
    /// <summary>
    /// Duration (minutes)
    /// </summary>
    public int Duration { get; set; }

    public string Director { get; set; }
}
