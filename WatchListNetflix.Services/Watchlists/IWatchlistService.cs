using WatchListNetflix.Model.Entities;
using WatchListNetflix.Services.Generic;

namespace WatchListNetflix.Services.Watchlists;

public interface IWatchlistService : ICrudService<Watchlist>
{
    Task InsertAudiovisual(int watchListId, List<int> audioviasualIds);

    Task RemoveAudiovisual(int watchListId, List<int> audioviasualIds);
}
