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

    public override async Task<List<Watchlist>> GetAllAsync()
    {
        return await _db.Set<Watchlist>().Include(x => x.Audiovisuals).ToListAsync();
    }
    public async Task InsertAudiovisual(int watchListId, List<int> audioviasualIds)
    {
        var watchList = _db.Set<Watchlist>().Include(x => x.Audiovisuals).FirstOrDefault();

        if (watchList is null)
        {
            throw new Exception($"The {nameof(Watchlist)} does not exist");
        }

        if (audioviasualIds is null || !audioviasualIds.Any()) 
        {
            throw new ArgumentNullException($"The list of {nameof(Serie)} or {nameof(Movie)} is empty");
        }

        foreach (var audiovisualId in audioviasualIds)
        {
            if (!watchList.Audiovisuals.Any(x => x.AudiovisualId == audiovisualId && x.WatchlistId == watchListId))
            {
                watchList.Audiovisuals.Add(new WatchlistAudiovisual { WatchlistId = watchList.Id, AudiovisualId = audiovisualId});
            }
        }

        await SaveChangeAsync();
    }

    public async Task RemoveAudiovisual(int watchListId, List<int> audioviasualIds)
    {
        var watchList = _db.Set<Watchlist>().Include(x => x.Audiovisuals).FirstOrDefault();

        if (watchList is null)
        {
            throw new Exception($"The {nameof(Watchlist)} does not exist");
        }

        if (audioviasualIds is null || !audioviasualIds.Any())
        {
            throw new ArgumentNullException($"The list of {nameof(Serie)} or {nameof(Movie)} is empty");
        }

        foreach (var audiovisualId in audioviasualIds)
        {
            if (watchList.Audiovisuals.Any(x => x.AudiovisualId == audiovisualId && x.WatchlistId == watchListId))
            {
                var watchlistaudiovisual = watchList.Audiovisuals
                    .FirstOrDefault(x => x.AudiovisualId == audiovisualId && x.WatchlistId == watchListId);
                watchList.Audiovisuals.Remove(watchlistaudiovisual);
            }
        }

        await SaveChangeAsync();
    }
}
