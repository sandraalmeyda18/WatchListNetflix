
using AutoMapper;
using WatchListNetflix.Model.Entities;
using WatchListNetflix.Services.Audiovisuals.Models;

namespace WatchListNetflix.Services.AutoMappers;

public class AudiovisualAutomapper : Profile
{
    public AudiovisualAutomapper()
    {
        CreateMap<Audiovisual, AudiovisualDto>()
            .ForMember(dest => dest.AudiovisualType, opt => opt.MapFrom(src => src.GetType().Name))
            .ReverseMap();

        CreateMap<Movie, MovieDto>().IncludeBase<Audiovisual, AudiovisualDto>().ReverseMap();
        CreateMap<Serie, SerieDto>().IncludeBase<Audiovisual, AudiovisualDto>().ReverseMap();

        CreateMap<Audiovisual, AddAudiovisualDto>()
            .ForMember(dest => dest.AudiovisualType, opt => opt.MapFrom(src => src.GetType().Name))
            .ReverseMap();

        CreateMap<Movie, AddMovieDto>().IncludeBase<Audiovisual, AddAudiovisualDto>().ReverseMap();
        CreateMap<Serie, AddSerieDto>().IncludeBase<Audiovisual, AddAudiovisualDto>().ReverseMap();

        CreateMap<Movie, UpdateMovieDto>().IncludeBase<Audiovisual, UpdateAudiovisualDto>().ReverseMap();
        CreateMap<Serie, UpdateSerieDto>().IncludeBase<Audiovisual, UpdateAudiovisualDto>().ReverseMap();
    }
}
