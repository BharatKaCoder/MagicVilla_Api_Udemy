using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_Api_Udemy.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaID",
                table: "VillaNumber",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 16, 5, 10, 840, DateTimeKind.Local).AddTicks(4178), new DateTime(2025, 1, 6, 16, 5, 10, 840, DateTimeKind.Local).AddTicks(4194) });

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 16, 5, 10, 840, DateTimeKind.Local).AddTicks(4196), new DateTime(2025, 1, 6, 16, 5, 10, 840, DateTimeKind.Local).AddTicks(4197) });

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 6, 16, 5, 10, 840, DateTimeKind.Local).AddTicks(4199), new DateTime(2025, 1, 6, 16, 5, 10, 840, DateTimeKind.Local).AddTicks(4199) });

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumber_VillaID",
                table: "VillaNumber",
                column: "VillaID");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumber_VillasTable_VillaID",
                table: "VillaNumber",
                column: "VillaID",
                principalTable: "VillasTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumber_VillasTable_VillaID",
                table: "VillaNumber");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumber_VillaID",
                table: "VillaNumber");

            migrationBuilder.DropColumn(
                name: "VillaID",
                table: "VillaNumber");

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
    }
}
