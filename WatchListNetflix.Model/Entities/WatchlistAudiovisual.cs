using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListNetflix.Model.Entities;

public class WatchlistAudiovisual : BaseEntity
{
    public int WatchlistId { get; set; }

    public Watchlist Watchlist { get; set; }

    public int AudiovisualId { get; set; }

    public Audiovisual Audiovisual { get; set; }
}
