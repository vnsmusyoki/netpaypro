using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompanyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Cities_Cityid",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "Cityid",
                table: "Companies",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_Cityid",
                table: "Companies",
                newName: "IX_Companies_CityId");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 21, 33, 42, 468, DateTimeKind.Local).AddTicks(4789), new DateTimeOffset(new DateTime(2025, 2, 9, 18, 33, 42, 468, DateTimeKind.Unspecified).AddTicks(4789), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 21, 33, 42, 468, DateTimeKind.Local).AddTicks(4765), new DateTimeOffset(new DateTime(2025, 2, 9, 18, 33, 42, 468, DateTimeKind.Unspecified).AddTicks(4766), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Cities_CityId",
                table: "Companies",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Cities_CityId",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Companies",
                newName: "Cityid");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_CityId",
                table: "Companies",
                newName: "IX_Companies_Cityid");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 21, 4, 4, 158, DateTimeKind.Local).AddTicks(3464), new DateTimeOffset(new DateTime(2025, 2, 9, 18, 4, 4, 158, DateTimeKind.Unspecified).AddTicks(3464), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 21, 4, 4, 158, DateTimeKind.Local).AddTicks(3435), new DateTimeOffset(new DateTime(2025, 2, 9, 18, 4, 4, 158, DateTimeKind.Unspecified).AddTicks(3436), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Cities_Cityid",
                table: "Companies",
                column: "Cityid",
                principalTable: "Cities",
                principalColumn: "Id");
        }
    }
}
