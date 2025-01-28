using WatchListNetflix.Model.Entities;
using WatchListNetflix.Services.Generic;

namespace WatchListNetflix.Services.Audiovisuals;

public interface IAudiovisualService : ICrudService<Audiovisual>
{
    Task<ICollection<Serie>> GetSeries();

    Task<ICollection<Movie>> GetMovies();
}
