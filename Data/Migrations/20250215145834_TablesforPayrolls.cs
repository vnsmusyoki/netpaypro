using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class TablesforPayrolls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 15, 17, 58, 31, 857, DateTimeKind.Local).AddTicks(8500), new DateTimeOffset(new DateTime(2025, 2, 15, 14, 58, 31, 857, DateTimeKind.Unspecified).AddTicks(8502), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 15, 17, 58, 31, 857, DateTimeKind.Local).AddTicks(8374), new DateTimeOffset(new DateTime(2025, 2, 15, 14, 58, 31, 857, DateTimeKind.Unspecified).AddTicks(8377), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 15, 17, 39, 15, 600, DateTimeKind.Local).AddTicks(2267), new DateTimeOffset(new DateTime(2025, 2, 15, 14, 39, 15, 600, DateTimeKind.Unspecified).AddTicks(2272), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 15, 17, 39, 15, 600, DateTimeKind.Local).AddTicks(1996), new DateTimeOffset(new DateTime(2025, 2, 15, 14, 39, 15, 600, DateTimeKind.Unspecified).AddTicks(2002), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
