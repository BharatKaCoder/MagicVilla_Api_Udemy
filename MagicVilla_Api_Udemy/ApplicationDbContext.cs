using MagicVilla_Api_Udemy.Models;
using MagicVilla_Api_Udemy.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_Api_Udemy
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) { }

        public DbSet<VillaModel> VillasTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Specify table name explicitly
            modelBuilder.Entity<VillaModel>().ToTable("VillasTable");

            // Seed data into VillasTable
            modelBuilder.Entity<VillaModel>().HasData(
                new VillaModel
                {
                    Id = 1,
                    Name = "Ocean View Villa",
                    Description = "A beautiful villa with a stunning ocean view, perfect for a relaxing getaway.",
                    Rate = 250.50,
                    SqFt = 2000,
                    ImageUrl = "https://example.com/images/oceanviewvilla.jpg",
                    Amenity = "Pool, WiFi, Parking",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new VillaModel
                {
                    Id = 2,
                    Name = "Mountain Retreat",
                    Description = "A cozy retreat in the mountains, ideal for nature lovers and adventure seekers.",
                    Rate = 180.75,
                    SqFt = 1500,
                    ImageUrl = "https://example.com/images/mountainretreat.jpg",
                    Amenity = "Fireplace, Hot Tub, WiFi",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new VillaModel
                {
                    Id = 3,
                    Name = "City Loft",
                    Description = "A modern loft in the heart of the city with easy access to all major attractions.",
                    Rate = 300.00,
                    SqFt = 1200,
                    ImageUrl = "https://example.com/images/cityloft.jpg",
                    Amenity = "Gym, Elevator, WiFi",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );
        }
    }
}

// Following command used to connect database
// 1) add-migration AddVillaTable
// 2) update-database

// Following command to overiride the migration.
// 1) Add-Migration SeedVillTable
// 2) update-database