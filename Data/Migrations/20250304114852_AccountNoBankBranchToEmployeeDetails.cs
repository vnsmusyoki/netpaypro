using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class AccountNoBankBranchToEmployeeDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_EmployeeDetails_Banks_BankId')
        ALTER TABLE EmployeeDetails DROP CONSTRAINT FK_EmployeeDetails_Banks_BankId;
    ");

            migrationBuilder.Sql(@"
        IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_EmployeeDetails_BankId')
        DROP INDEX IX_EmployeeDetails_BankId ON EmployeeDetails;
    ");

            // Drop the column safely
            migrationBuilder.Sql(@"
        IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
                   WHERE TABLE_NAME = 'EmployeeDetails' AND COLUMN_NAME = 'BankId')
        ALTER TABLE EmployeeDetails DROP COLUMN BankId;
    ");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 14, 48, 50, 519, DateTimeKind.Local).AddTicks(5128), new DateTimeOffset(new DateTime(2025, 3, 4, 11, 48, 50, 519, DateTimeKind.Unspecified).AddTicks(5129), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 14, 48, 50, 519, DateTimeKind.Local).AddTicks(5073), new DateTimeOffset(new DateTime(2025, 3, 4, 11, 48, 50, 519, DateTimeKind.Unspecified).AddTicks(5074), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "EmployeeDetails",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 16, 54, 13, 707, DateTimeKind.Local).AddTicks(5703), new DateTimeOffset(new DateTime(2025, 2, 25, 13, 54, 13, 707, DateTimeKind.Unspecified).AddTicks(5705), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 16, 54, 13, 707, DateTimeKind.Local).AddTicks(5453), new DateTimeOffset(new DateTime(2025, 2, 25, 13, 54, 13, 707, DateTimeKind.Unspecified).AddTicks(5454), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_BankId",
                table: "EmployeeDetails",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDetails_Banks_BankId",
                table: "EmployeeDetails",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");
        }
    }
}
