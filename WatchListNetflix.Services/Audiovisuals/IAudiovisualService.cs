using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListNetflix.Model.Entities;

namespace WatchListNetflix.Services.Audiovisuals;

public interface IAudiovisualService : ICrudService<Audiovisual>
{
    Task<List<Serie>> GetSeries();

    Task<List<Movie>> GetMovies();
}
