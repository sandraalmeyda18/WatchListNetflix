using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListNetflix.Model.Entities;
using WatchListNetflix.Services.Audiovisuals.Models;
using WatchListNetflix.Services.Users.Models;

namespace WatchListNetflix.Services.Mappers;

public class UserAutomappers : Profile
{
    public UserAutomappers()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
