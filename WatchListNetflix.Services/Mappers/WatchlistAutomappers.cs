using AutoMapper;
using WatchListNetflix.Model.Entities;
using WatchListNetflix.Services.Watchlists.Models;

namespace WatchListNetflix.Services.Mappers;

public class WatchlistAutomappers : Profile
{
    public WatchlistAutomappers()
    {
        CreateMap<Watchlist, WatchlistDto>().ReverseMap();
        CreateMap<Watchlist, AddWatchlistDto>().ReverseMap();
        CreateMap<Watchlist, UpdateWatchListDto>().ReverseMap();
    }
}
