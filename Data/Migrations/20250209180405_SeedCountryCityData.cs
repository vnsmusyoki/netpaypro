using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCountryCityData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "CountryName", "CreatedAt", "DeletedAt", "LastUpdatedAt" },
                values: new object[] { 1, "254", "Kenya", new DateTime(2025, 2, 9, 21, 4, 4, 158, DateTimeKind.Local).AddTicks(3435), null, new DateTimeOffset(new DateTime(2025, 2, 9, 18, 4, 4, 158, DateTimeKind.Unspecified).AddTicks(3436), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "CountryId", "CreatedAt", "DeletedAt", "LastUpdatedAt" },
                values: new object[] { 1, "Nairobi", 1, new DateTime(2025, 2, 9, 21, 4, 4, 158, DateTimeKind.Local).AddTicks(3464), null, new DateTimeOffset(new DateTime(2025, 2, 9, 18, 4, 4, 158, DateTimeKind.Unspecified).AddTicks(3464), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Companies");
        }
    }
}
