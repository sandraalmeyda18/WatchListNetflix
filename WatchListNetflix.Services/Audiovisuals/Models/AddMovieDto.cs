namespace WatchListNetflix.Services.Audiovisuals.Models;

public class AddMovieDto : AddAudiovisualDto
{
    /// <summary>
    /// Duration (minutes)
    /// </summary>
    public int Duration { get; set; }

    public string Director { get; set; }
}
