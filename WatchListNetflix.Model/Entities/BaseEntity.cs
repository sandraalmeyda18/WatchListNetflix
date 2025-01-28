using System.ComponentModel.DataAnnotations;

namespace WatchListNetflix.Model.Entities;

public class BaseEntity
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Date Created")]
    public DateTime CreatedAt { get; set; }

    [Required]
    [Display(Name = "Date Updated")]
    public DateTime UpdatedAt { get; set; }
}
