using WatchListNetflix.Model.Entities;
using WatchListNetflix.Services.Generic.Models;

namespace WatchListNetflix.Services.Audiovisuals.Models;

public class AudiovisualDto : BaseEntityDto
{
    public string Title { get; set; }

    public string Synopsis { get; set; }

    public DateTime ReleaseDate { get; set; }

    public Category Category { get; set; }

    public string AudiovisualType { get; set; }
}
