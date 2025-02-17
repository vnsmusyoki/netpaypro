using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBranchesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 17, 14, 27, 43, 133, DateTimeKind.Local).AddTicks(5198), new DateTimeOffset(new DateTime(2025, 2, 17, 11, 27, 43, 133, DateTimeKind.Unspecified).AddTicks(5199), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 17, 14, 27, 43, 133, DateTimeKind.Local).AddTicks(5116), new DateTimeOffset(new DateTime(2025, 2, 17, 11, 27, 43, 133, DateTimeKind.Unspecified).AddTicks(5118), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 17, 14, 19, 27, 554, DateTimeKind.Local).AddTicks(2543), new DateTimeOffset(new DateTime(2025, 2, 17, 11, 19, 27, 554, DateTimeKind.Unspecified).AddTicks(2546), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 17, 14, 19, 27, 554, DateTimeKind.Local).AddTicks(2299), new DateTimeOffset(new DateTime(2025, 2, 17, 11, 19, 27, 554, DateTimeKind.Unspecified).AddTicks(2302), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
