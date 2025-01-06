using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_Api_Udemy.Migrations
{
    /// <inheritdoc />
    public partial class AddVillaNumberToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumber",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumber", x => x.VillaNo);
                });

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 12, 36, 23, 822, DateTimeKind.Local).AddTicks(9185), new DateTime(2025, 1, 6, 12, 36, 23, 822, DateTimeKind.Local).AddTicks(9196) });

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 12, 36, 23, 822, DateTimeKind.Local).AddTicks(9199), new DateTime(2025, 1, 6, 12, 36, 23, 822, DateTimeKind.Local).AddTicks(9200) });

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 12, 36, 23, 822, DateTimeKind.Local).AddTicks(9201), new DateTime(2025, 1, 6, 12, 36, 23, 822, DateTimeKind.Local).AddTicks(9202) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumber");

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 22, 23, 10, 724, DateTimeKind.Local).AddTicks(5442), new DateTime(2025, 1, 4, 22, 23, 10, 724, DateTimeKind.Local).AddTicks(5454) });

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 22, 23, 10, 724, DateTimeKind.Local).AddTicks(5457), new DateTime(2025, 1, 4, 22, 23, 10, 724, DateTimeKind.Local).AddTicks(5458) });

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 4, 22, 23, 10, 724, DateTimeKind.Local).AddTicks(5459), new DateTime(2025, 1, 4, 22, 23, 10, 724, DateTimeKind.Local).AddTicks(5460) });
        }
    }
}
