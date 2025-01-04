using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_Api_Udemy.Models
{
    public class VillaModel
    {
        [Key] // It is setting as promary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // this will create automatic ID
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
        public int SqFt { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity {  get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
