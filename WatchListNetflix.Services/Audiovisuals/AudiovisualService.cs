using Microsoft.EntityFrameworkCore;
using WatchListNetflix.Data;
using WatchListNetflix.Model.Entities;
using WatchListNetflix.Services.Generic;

namespace WatchListNetflix.Services.Audiovisuals;

public class AudiovisualService : CrudService<Audiovisual>, IAudiovisualService
{
    private readonly WatchListNetflixContext _db;

    public AudiovisualService(WatchListNetflixContext db) : base(db)
    {
        _db = db;
    }

    public async Task<ICollection<Movie>> GetMovies()
    {
        var audiovisuals = await GetAllAsync();
        return audiovisuals.OfType<Movie>().ToList();
    }

    public async Task<ICollection<Serie>> GetSeries()
    {
        var audiovisuals = await GetAllAsync();
        return audiovisuals.OfType<Serie>().ToList();
    }

    public async Task<List<Audiovisual>> SearchAudiovisuals(string title = null, string tipo = null, DateTime? startReleaseDate = null, Category? category = null, int page = 1,
        int pageSize = 10)
    {
        var query = _db.Set<Audiovisual>().AsQueryable();

        if (!string.IsNullOrEmpty(title))
            query = query.Where(a => a.Title.Contains(title));

        if (!string.IsNullOrEmpty(tipo))
            query = query.Where(a => EF.Property<string>(a, "AudiovisualType") == tipo);

        if (startReleaseDate is not null)
        {
            query = query.Where(a => a.ReleaseDate >= startReleaseDate);
        }

        if (category is not null)
        {
            query = query.Where(a => a.Category.Equals(category));
        }

        // Pagination
        return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }

}
