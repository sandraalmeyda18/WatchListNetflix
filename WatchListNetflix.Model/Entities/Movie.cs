﻿namespace WatchListNetflix.Model.Entities;

public class Movie : Audiovisual
{
    public int SeasonsNumber { get; set; }

    public bool? OnAir { get; set; }
}
