using WatchListNetflix.Model.Entities;

namespace WatchListNetflix.Services.Audiovisuals;

public interface IAudiovisualService : ICrudService<Audiovisual>
{
    Task<ICollection<Serie>> GetSeries();

    Task<ICollection<Movie>> GetMovies();
}
