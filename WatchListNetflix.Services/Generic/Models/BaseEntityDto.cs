using System.ComponentModel.DataAnnotations;

namespace WatchListNetflix.Services.Generic.Models;

public class BaseEntityDto
{
    public int Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }
}
