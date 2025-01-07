using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_Api_Udemy.Migrations
{
    /// <inheritdoc />
    public partial class addedNullableChecksDisabled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpecialDetails",
                table: "VillaNumber",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpecialDetails",
                table: "VillaNumber",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 12, 25, 30, 700, DateTimeKind.Local).AddTicks(8303), new DateTime(2025, 1, 7, 12, 25, 30, 700, DateTimeKind.Local).AddTicks(8313) });

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 12, 25, 30, 700, DateTimeKind.Local).AddTicks(8315), new DateTime(2025, 1, 7, 12, 25, 30, 700, DateTimeKind.Local).AddTicks(8316) });

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 7, 12, 25, 30, 700, DateTimeKind.Local).AddTicks(8317), new DateTime(2025, 1, 7, 12, 25, 30, 700, DateTimeKind.Local).AddTicks(8318) });
        }
    }
}
