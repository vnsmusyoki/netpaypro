using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayrollEntries_payRollEntriesSummaries_PayrollEntriesSummaryId",
                table: "PayrollEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_payRollEntriesSummaries_AspNetUsers_SubmittedById",
                table: "payRollEntriesSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_payRollEntriesSummaries_AspNetUsers_UserId",
                table: "payRollEntriesSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_payRollEntriesSummaries_Companies_CompanyId",
                table: "payRollEntriesSummaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_payRollEntriesSummaries",
                table: "payRollEntriesSummaries");

            migrationBuilder.RenameTable(
                name: "payRollEntriesSummaries",
                newName: "PayRollEntriesSummaries");

            migrationBuilder.RenameIndex(
                name: "IX_payRollEntriesSummaries_UserId",
                table: "PayRollEntriesSummaries",
                newName: "IX_PayRollEntriesSummaries_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_payRollEntriesSummaries_SubmittedById",
                table: "PayRollEntriesSummaries",
                newName: "IX_PayRollEntriesSummaries_SubmittedById");

            migrationBuilder.RenameIndex(
                name: "IX_payRollEntriesSummaries_CompanyId",
                table: "PayRollEntriesSummaries",
                newName: "IX_PayRollEntriesSummaries_CompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "PayrollYear",
                table: "PayRollEntriesSummaries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PayrollMonth",
                table: "PayRollEntriesSummaries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayRollEntriesSummaries",
                table: "PayRollEntriesSummaries",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollEntries_PayRollEntriesSummaries_PayrollEntriesSummaryId",
                table: "PayrollEntries",
                column: "PayrollEntriesSummaryId",
                principalTable: "PayRollEntriesSummaries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PayRollEntriesSummaries_AspNetUsers_SubmittedById",
                table: "PayRollEntriesSummaries",
                column: "SubmittedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PayRollEntriesSummaries_AspNetUsers_UserId",
                table: "PayRollEntriesSummaries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayRollEntriesSummaries_Companies_CompanyId",
                table: "PayRollEntriesSummaries",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayrollEntries_PayRollEntriesSummaries_PayrollEntriesSummaryId",
                table: "PayrollEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_PayRollEntriesSummaries_AspNetUsers_SubmittedById",
                table: "PayRollEntriesSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_PayRollEntriesSummaries_AspNetUsers_UserId",
                table: "PayRollEntriesSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_PayRollEntriesSummaries_Companies_CompanyId",
                table: "PayRollEntriesSummaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayRollEntriesSummaries",
                table: "PayRollEntriesSummaries");

            migrationBuilder.RenameTable(
                name: "PayRollEntriesSummaries",
                newName: "payRollEntriesSummaries");

            migrationBuilder.RenameIndex(
                name: "IX_PayRollEntriesSummaries_UserId",
                table: "payRollEntriesSummaries",
                newName: "IX_payRollEntriesSummaries_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PayRollEntriesSummaries_SubmittedById",
                table: "payRollEntriesSummaries",
                newName: "IX_payRollEntriesSummaries_SubmittedById");

            migrationBuilder.RenameIndex(
                name: "IX_PayRollEntriesSummaries_CompanyId",
                table: "payRollEntriesSummaries",
                newName: "IX_payRollEntriesSummaries_CompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "PayrollYear",
                table: "payRollEntriesSummaries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PayrollMonth",
                table: "payRollEntriesSummaries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_payRollEntriesSummaries",
                table: "payRollEntriesSummaries",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollEntries_payRollEntriesSummaries_PayrollEntriesSummaryId",
                table: "PayrollEntries",
                column: "PayrollEntriesSummaryId",
                principalTable: "payRollEntriesSummaries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_payRollEntriesSummaries_AspNetUsers_SubmittedById",
                table: "payRollEntriesSummaries",
                column: "SubmittedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_payRollEntriesSummaries_AspNetUsers_UserId",
                table: "payRollEntriesSummaries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_payRollEntriesSummaries_Companies_CompanyId",
                table: "payRollEntriesSummaries",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
