using Microsoft.EntityFrameworkCore;
using WatchListNetflix.Data;
using WatchListNetflix.Model.Entities;
using WatchListNetflix.Services.Generic;

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
            if (!watchList.Audiovisuals.Any(x => x.AudiovisualId == audiovisual.Id && x.WatchlistId == watchListId))
            {
                watchList.Audiovisuals.Add(new WatchlistAudiovisual { WatchlistId = watchList.Id, AudiovisualId = audiovisual.Id});
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
            if (watchList.Audiovisuals.Any(x => x.AudiovisualId == audiovisual.Id && x.WatchlistId == watchListId))
            {
                var watchlistaudiovisual = watchList.Audiovisuals
                    .FirstOrDefault(x => x.AudiovisualId == audiovisual.Id && x.WatchlistId == watchListId);
                watchList.Audiovisuals.Remove(watchlistaudiovisual);
            }
        }

        await SaveChangeAsync();
    }
}
