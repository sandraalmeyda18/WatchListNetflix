using System.ComponentModel.DataAnnotations;
using WatchListNetflix.Model.Entities;

namespace WatchListNetflix.Services.Audiovisuals.Models;

public class UpdateAudiovisualDto
{
    public int Id { get; set; }

    [Required]
    [MinLength(10, ErrorMessage = "The title does not have the minimum number of characters required")]
    [MaxLength(50, ErrorMessage = "The title exceeds the maximum number of characters required")]
    public string Title { get; set; }

    [MaxLength(500, ErrorMessage = "The title exceeds the maximum number of characters required")]
    public string Synopsis { get; set; }

    [Required]
    public DateTime ReleaseDate { get; set; }

    public Category Category { get; set; }
    public string AudiovisualType { get; set; }
}
