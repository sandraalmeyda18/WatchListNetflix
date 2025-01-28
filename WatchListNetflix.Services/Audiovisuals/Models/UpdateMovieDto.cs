namespace WatchListNetflix.Services.Audiovisuals.Models;

public class UpdateMovieDto : UpdateAudiovisualDto
{
    /// <summary>
    /// Duration (minutes)
    /// </summary>
    public int Duration { get; set; }

    public string Director { get; set; }
}
