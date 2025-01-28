using WatchListNetflix.Model.Entities;

namespace WatchListNetflix.Services.Watchlists;

public interface IWatchlistService : ICrudService<Watchlist>
{
    Task InsertAudiovisual(int watchListId, List<Audiovisual> audioviasuals);
}
