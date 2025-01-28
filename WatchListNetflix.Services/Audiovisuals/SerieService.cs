using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListNetflix.Data;
using WatchListNetflix.Model.Entities;

namespace WatchListNetflix.Services.Audiovisuals;

public class SerieService : CrudService<Serie>, ISerieService
{
    public SerieService(WatchListNetflixContext db) : base(db)
    {
    }
}
