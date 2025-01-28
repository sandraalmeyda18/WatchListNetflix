using System.ComponentModel.DataAnnotations;
using WatchListNetflix.Services.Generic.Models;
using WatchListNetflix.Services.Users.Models;

namespace WatchListNetflix.Services.Watchlists.Models;

public class WatchlistDto : BaseEntityDto
{
    [Required]
    [MinLength(10, ErrorMessage = "The name does not have the minimum number of characters required")]
    [MaxLength(50, ErrorMessage = "The name exceeds the maximum number of characters required")]
    public string Name { get; set; }

    UserDto User { get; set; }
}
