using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListNetflix.Data;
using WatchListNetflix.Model.Entities;

namespace WatchListNetflix.Services.Audiovisuals;

public class AudiovisualService : CrudService<Audiovisual>, IAudiovisualService
{
    public AudiovisualService(WatchListNetflixContext db) : base(db)
    {
    }

    public async Task<ICollection<Movie>> GetMovies()
    {
        throw new NotImplementedException();
    }

    public Task<List<Serie>> GetSeries()
    {
        throw new NotImplementedException();
    }
}
