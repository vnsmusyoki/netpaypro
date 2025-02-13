using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 13, 11, 46, 20, 143, DateTimeKind.Local).AddTicks(8621), new DateTimeOffset(new DateTime(2025, 2, 13, 8, 46, 20, 143, DateTimeKind.Unspecified).AddTicks(8622), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 13, 11, 46, 20, 143, DateTimeKind.Local).AddTicks(8563), new DateTimeOffset(new DateTime(2025, 2, 13, 8, 46, 20, 143, DateTimeKind.Unspecified).AddTicks(8565), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
