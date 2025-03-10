﻿using System.ComponentModel.DataAnnotations;

namespace WatchListNetflix.Model.Entities;

public class BaseEntity
{
    public int Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }
}
