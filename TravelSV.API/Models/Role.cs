﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TravelSV.API.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public record class Role
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
