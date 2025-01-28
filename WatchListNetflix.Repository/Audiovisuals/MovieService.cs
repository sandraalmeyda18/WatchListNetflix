using WatchListNetflix.Data;
using WatchListNetflix.Model.Entities;

namespace WatchListNetflix.Services.Audiovisuals;

public class MovieService : CrudService<Movie>, IMovieService
{
    public MovieService(WatchListNetflixContext db) : base(db)
    {
    }
}
