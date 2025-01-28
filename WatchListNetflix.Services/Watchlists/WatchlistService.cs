using Microsoft.EntityFrameworkCore;
using WatchListNetflix.Data;
using WatchListNetflix.Model.Entities;

namespace WatchListNetflix.Services.Watchlists;

public class WatchlistService : CrudService<Watchlist>, IWatchlistService
{
    private readonly WatchListNetflixContext _db;

    public WatchlistService(WatchListNetflixContext db) : base(db)
    {
        _db = db;
    }

    public async Task InsertAudiovisual(int watchListId, List<Audiovisual> audioviasuals)
    {
        var watchList = _db.Set<Watchlist>().Include(x => x.Audiovisuals).FirstOrDefault();

        if (watchList is null)
        {
            throw new Exception($"The {nameof(Watchlist)} does not exist");
        }

        if (audioviasuals is null || !audioviasuals.Any()) 
        {
            throw new ArgumentNullException($"The list of {nameof(Serie)} or {nameof(Movie)} is empty");
        }

        foreach (var audiovisual in audioviasuals)
        {
            if (!watchList.Audiovisuals.Any(x => x.Id == audiovisual.Id))
            {
                watchList.Audiovisuals.Add(audiovisual);
            }
        }

        await SaveChangeAsync();
    }

    public async Task RemoveAudiovisual(int watchListId, List<Audiovisual> audioviasuals)
    {
        var watchList = _db.Set<Watchlist>().Include(x => x.Audiovisuals).FirstOrDefault();

        if (watchList is null)
        {
            throw new Exception($"The {nameof(Watchlist)} does not exist");
        }

        if (audioviasuals is null || !audioviasuals.Any())
        {
            throw new ArgumentNullException($"The list of {nameof(Serie)} or {nameof(Movie)} is empty");
        }

        foreach (var audiovisual in audioviasuals)
        {
            if (watchList.Audiovisuals.Any(x => x.Id == audiovisual.Id))
            {
                watchList.Audiovisuals.Remove(audiovisual);
            }
        }

        await SaveChangeAsync();
    }
}
