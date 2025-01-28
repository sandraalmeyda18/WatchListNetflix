using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListNetflix.Services.Audiovisuals.Models;

public class UpdateSerieDto : UpdateAudiovisualDto
{
    public int SeasonsNumber { get; set; }

    public int EpisodesNumber { get; set; }

    public bool? OnAir { get; set; }
}
