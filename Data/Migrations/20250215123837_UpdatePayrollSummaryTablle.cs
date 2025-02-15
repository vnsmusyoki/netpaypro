using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePayrollSummaryTablle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PayrollMonth",
                table: "payRollEntriesSummaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PayrollYear",
                table: "payRollEntriesSummaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmitedBy",
                table: "payRollEntriesSummaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SubmittedById",
                table: "payRollEntriesSummaries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubmittedByUserId",
                table: "payRollEntriesSummaries",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_payRollEntriesSummaries_SubmittedById",
                table: "payRollEntriesSummaries",
                column: "SubmittedById");

            migrationBuilder.AddForeignKey(
                name: "FK_payRollEntriesSummaries_AspNetUsers_SubmittedById",
                table: "payRollEntriesSummaries",
                column: "SubmittedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payRollEntriesSummaries_AspNetUsers_SubmittedById",
                table: "payRollEntriesSummaries");

            migrationBuilder.DropIndex(
                name: "IX_payRollEntriesSummaries_SubmittedById",
                table: "payRollEntriesSummaries");

            migrationBuilder.DropColumn(
                name: "PayrollMonth",
                table: "payRollEntriesSummaries");

            migrationBuilder.DropColumn(
                name: "PayrollYear",
                table: "payRollEntriesSummaries");

            migrationBuilder.DropColumn(
                name: "SubmitedBy",
                table: "payRollEntriesSummaries");

            migrationBuilder.DropColumn(
                name: "SubmittedById",
                table: "payRollEntriesSummaries");

            migrationBuilder.DropColumn(
                name: "SubmittedByUserId",
                table: "payRollEntriesSummaries");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 15, 15, 12, 54, 489, DateTimeKind.Local).AddTicks(9712), new DateTimeOffset(new DateTime(2025, 2, 15, 12, 12, 54, 489, DateTimeKind.Unspecified).AddTicks(9713), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 15, 15, 12, 54, 489, DateTimeKind.Local).AddTicks(9688), new DateTimeOffset(new DateTime(2025, 2, 15, 12, 12, 54, 489, DateTimeKind.Unspecified).AddTicks(9689), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
