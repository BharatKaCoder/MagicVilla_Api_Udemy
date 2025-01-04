using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_Api_Udemy.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VillasTable",
                columns: new[] { "Id", "Amenity", "CreatedAt", "Description", "ImageUrl", "Name", "Rate", "SqFt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Pool, WiFi, Parking", new DateTime(2025, 1, 4, 22, 23, 10, 724, DateTimeKind.Local).AddTicks(5442), "A beautiful villa with a stunning ocean view, perfect for a relaxing getaway.", "https://example.com/images/oceanviewvilla.jpg", "Ocean View Villa", 250.5, 2000, new DateTime(2025, 1, 4, 22, 23, 10, 724, DateTimeKind.Local).AddTicks(5454) },
                    { 2, "Fireplace, Hot Tub, WiFi", new DateTime(2025, 1, 4, 22, 23, 10, 724, DateTimeKind.Local).AddTicks(5457), "A cozy retreat in the mountains, ideal for nature lovers and adventure seekers.", "https://example.com/images/mountainretreat.jpg", "Mountain Retreat", 180.75, 1500, new DateTime(2025, 1, 4, 22, 23, 10, 724, DateTimeKind.Local).AddTicks(5458) },
                    { 3, "Gym, Elevator, WiFi", new DateTime(2025, 1, 4, 22, 23, 10, 724, DateTimeKind.Local).AddTicks(5459), "A modern loft in the heart of the city with easy access to all major attractions.", "https://example.com/images/cityloft.jpg", "City Loft", 300.0, 1200, new DateTime(2025, 1, 4, 22, 23, 10, 724, DateTimeKind.Local).AddTicks(5460) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
