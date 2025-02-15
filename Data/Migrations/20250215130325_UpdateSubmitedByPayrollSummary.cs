using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSubmitedByPayrollSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubmitedBy",
                table: "payRollEntriesSummaries",
                newName: "SubmitedAt");

            migrationBuilder.RenameColumn(
                name: "IsSubmited",
                table: "payRollEntriesSummaries",
                newName: "IsSubmitted");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 15, 16, 3, 22, 278, DateTimeKind.Local).AddTicks(6451), new DateTimeOffset(new DateTime(2025, 2, 15, 13, 3, 22, 278, DateTimeKind.Unspecified).AddTicks(6452), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 15, 16, 3, 22, 278, DateTimeKind.Local).AddTicks(6351), new DateTimeOffset(new DateTime(2025, 2, 15, 13, 3, 22, 278, DateTimeKind.Unspecified).AddTicks(6353), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubmitedAt",
                table: "payRollEntriesSummaries",
                newName: "SubmitedBy");

            migrationBuilder.RenameColumn(
                name: "IsSubmitted",
                table: "payRollEntriesSummaries",
                newName: "IsSubmited");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 15, 15, 38, 34, 404, DateTimeKind.Local).AddTicks(335), new DateTimeOffset(new DateTime(2025, 2, 15, 12, 38, 34, 404, DateTimeKind.Unspecified).AddTicks(336), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 15, 15, 38, 34, 404, DateTimeKind.Local).AddTicks(244), new DateTimeOffset(new DateTime(2025, 2, 15, 12, 38, 34, 404, DateTimeKind.Unspecified).AddTicks(246), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
