namespace WatchListNetflix.Services.Audiovisuals.Models;

public class AddSerieDto : AddAudiovisualDto
{
    public int SeasonsNumber { get; set; }

    public int EpisodesNumber { get; set; }

    public bool? OnAir { get; set; }
}
