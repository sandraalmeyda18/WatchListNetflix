﻿namespace WatchListNetflix.Model.Entities;

public class Serie : Audiovisual
{
    public int SeasonsNumber { get; set; }

    public int EpisodesNumber { get; set; }

    public bool? OnAir { get; set; }
}
