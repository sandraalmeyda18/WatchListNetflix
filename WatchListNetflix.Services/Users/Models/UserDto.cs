using WatchListNetflix.Services.Generic.Models;

namespace WatchListNetflix.Services.Users.Models;

public class UserDto : BaseEntityDto
{
    public string Name { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }
}
