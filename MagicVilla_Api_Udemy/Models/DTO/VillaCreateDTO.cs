﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Api_Udemy.Models.DTO
{
    public class VillaCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Rate { get; set; }
        public int SqFt { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
    }
}
