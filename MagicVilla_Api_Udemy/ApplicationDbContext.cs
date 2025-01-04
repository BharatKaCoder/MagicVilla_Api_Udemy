using MagicVilla_Api_Udemy.Models;
using MagicVilla_Api_Udemy.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_Api_Udemy
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) { }

        public DbSet<VillaModel> VillasTable { get; set; }
    }
}
