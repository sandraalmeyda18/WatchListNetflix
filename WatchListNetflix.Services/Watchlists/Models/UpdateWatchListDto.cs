using System.ComponentModel.DataAnnotations;

namespace WatchListNetflix.Services.Watchlists.Models;

public class UpdateWatchListDto
{
    public int Id { get; set; }

    [Required]
    [MinLength(10, ErrorMessage = "The name does not have the minimum number of characters required")]
    [MaxLength(50, ErrorMessage = "The name exceeds the maximum number of characters required")]
    public string Name { get; set; }
}
