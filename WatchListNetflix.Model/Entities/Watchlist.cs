using System.ComponentModel.DataAnnotations;

namespace WatchListNetflix.Model.Entities;

public class Watchlist : BaseEntity
{
    [Required]
    [MinLength(10, ErrorMessage = "The name does not have the minimum number of characters required")]
    [MaxLength(50, ErrorMessage = "The name exceeds the maximum number of characters required")]
    public string Name { get; set; }

    public int ClientId { get; set; }

    public ICollection<WatchlistAudiovisual> Audiovisuals { get; set; }
}
