using System.ComponentModel.DataAnnotations;

namespace MagicVillaUdemy_Web.Models.DTO
{
    public class VillaUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public int SqFt { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Amenity { get; set; }
    }
}
