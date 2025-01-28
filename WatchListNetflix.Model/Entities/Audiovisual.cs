using System.ComponentModel.DataAnnotations;

namespace WatchListNetflix.Model.Entities;

public enum Category
{
    None,
    Suspense,
    Family,
    Action
}

public abstract class Audiovisual : BaseEntity
{
    [Required]
    [MinLength(10, ErrorMessage = "The title does not have the minimum number of characters required")]
    [MaxLength(50, ErrorMessage = "The title exceeds the maximum number of characters required")]
    public string Title { get; set; }

    [MaxLength(500, ErrorMessage = "The title exceeds the maximum number of characters required")]
    public string Synopsis { get; set; }

    [Required]
    public DateTime ReleaseDate { get; set; }

    public Category Category { get; set; }
}
