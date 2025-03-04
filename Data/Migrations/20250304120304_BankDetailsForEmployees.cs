using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class BankDetailsForEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Banks')
        BEGIN
            CREATE TABLE Banks (
                Id INT IDENTITY(1,1) PRIMARY KEY,
                Name NVARCHAR(255) NOT NULL
            );
        END
    ");

            migrationBuilder.Sql(@"
        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'BankBranches')
        BEGIN
            CREATE TABLE BankBranches (
                Id INT IDENTITY(1,1) PRIMARY KEY,
                BankId INT NOT NULL,
                BranchName NVARCHAR(255) NOT NULL,
                FOREIGN KEY (BankId) REFERENCES Banks(Id) ON DELETE CASCADE
            );
        END
    ");

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "EmployeeDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AccountNo",
                table: "EmployeeDetails",
                type: "nvarchar(max)",
                nullable: true);

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
                values: new object[] { new DateTime(2025, 3, 4, 15, 3, 2, 431, DateTimeKind.Local).AddTicks(6039), new DateTimeOffset(new DateTime(2025, 3, 4, 12, 3, 2, 431, DateTimeKind.Unspecified).AddTicks(6040), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 15, 3, 2, 431, DateTimeKind.Local).AddTicks(5993), new DateTimeOffset(new DateTime(2025, 3, 4, 12, 3, 2, 431, DateTimeKind.Unspecified).AddTicks(5994), new TimeSpan(0, 0, 0, 0, 0)) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_Banks_BankId",
                table: "EmployeeDetails");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDetails_BankId",
                table: "EmployeeDetails");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "EmployeeDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "EmployeeDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountNo",
                table: "EmployeeDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
