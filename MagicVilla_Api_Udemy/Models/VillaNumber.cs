using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_Api_Udemy.Models
{
    public class VillaNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaNo { get; set; }

        // This is adding foreign ke join the table  "VillaM" is asssigned to it.
        [ForeignKey("Villa")]
        public int VillaID { get; set; }

        public VillaModel Villa {  get; set; } // created for foreign key
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
