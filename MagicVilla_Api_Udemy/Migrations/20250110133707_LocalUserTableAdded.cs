using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_Api_Udemy.Migrations
{
    /// <inheritdoc />
    public partial class LocalUserTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 10, 19, 7, 5, 293, DateTimeKind.Local).AddTicks(7863), new DateTime(2025, 1, 10, 19, 7, 5, 293, DateTimeKind.Local).AddTicks(7873) });

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 10, 19, 7, 5, 293, DateTimeKind.Local).AddTicks(7876), new DateTime(2025, 1, 10, 19, 7, 5, 293, DateTimeKind.Local).AddTicks(7876) });

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 10, 19, 7, 5, 293, DateTimeKind.Local).AddTicks(7878), new DateTime(2025, 1, 10, 19, 7, 5, 293, DateTimeKind.Local).AddTicks(7879) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 42, 32, 5, DateTimeKind.Local).AddTicks(9705), new DateTime(2025, 1, 7, 13, 42, 32, 5, DateTimeKind.Local).AddTicks(9715) });

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 42, 32, 5, DateTimeKind.Local).AddTicks(9717), new DateTime(2025, 1, 7, 13, 42, 32, 5, DateTimeKind.Local).AddTicks(9717) });

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 13, 42, 32, 5, DateTimeKind.Local).AddTicks(9719), new DateTime(2025, 1, 7, 13, 42, 32, 5, DateTimeKind.Local).AddTicks(9719) });
        }
    }
}
