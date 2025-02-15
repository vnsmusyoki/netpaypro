using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPayrollSummaryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsProcessed",
                table: "PayrollEntries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PayrollEntriesSummaryId",
                table: "PayrollEntries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "payRollEntriesSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordsCount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsSubmited = table.Column<bool>(type: "bit", nullable: false),
                    IsProcessedSuccessfully = table.Column<bool>(type: "bit", nullable: false),
                    FailedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payRollEntriesSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payRollEntriesSummaries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payRollEntriesSummaries_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PayrollEntries_PayrollEntriesSummaryId",
                table: "PayrollEntries",
                column: "PayrollEntriesSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_payRollEntriesSummaries_CompanyId",
                table: "payRollEntriesSummaries",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_payRollEntriesSummaries_UserId",
                table: "payRollEntriesSummaries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollEntries_payRollEntriesSummaries_PayrollEntriesSummaryId",
                table: "PayrollEntries",
                column: "PayrollEntriesSummaryId",
                principalTable: "payRollEntriesSummaries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayrollEntries_payRollEntriesSummaries_PayrollEntriesSummaryId",
                table: "PayrollEntries");

            migrationBuilder.DropTable(
                name: "payRollEntriesSummaries");

            migrationBuilder.DropIndex(
                name: "IX_PayrollEntries_PayrollEntriesSummaryId",
                table: "PayrollEntries");

            migrationBuilder.DropColumn(
                name: "IsProcessed",
                table: "PayrollEntries");

            migrationBuilder.DropColumn(
                name: "PayrollEntriesSummaryId",
                table: "PayrollEntries");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 14, 20, 33, 12, 268, DateTimeKind.Local).AddTicks(4679), new DateTimeOffset(new DateTime(2025, 2, 14, 17, 33, 12, 268, DateTimeKind.Unspecified).AddTicks(4680), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 14, 20, 33, 12, 268, DateTimeKind.Local).AddTicks(4583), new DateTimeOffset(new DateTime(2025, 2, 14, 17, 33, 12, 268, DateTimeKind.Unspecified).AddTicks(4585), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
