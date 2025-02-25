using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBankBranchAccountToEmployeeDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_EmployeeDetails_BankBranches_BankBranchId') " +
                        "ALTER TABLE EmployeeDetails DROP CONSTRAINT FK_EmployeeDetails_BankBranches_BankBranchId;");

            migrationBuilder.Sql("IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_EmployeeDetails_Banks_BankId') " +
                         "ALTER TABLE EmployeeDetails DROP CONSTRAINT FK_EmployeeDetails_Banks_BankId;");



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

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_BankBranches_BankBranchId",
                table: "EmployeeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_Banks_BankId",
                table: "EmployeeDetails");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "BankBranches");

            migrationBuilder.AlterColumn<int>(
                name: "BankId",
                table: "EmployeeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BankBranchId",
                table: "EmployeeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SwiftCode",
                table: "Banks",
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
                values: new object[] { new DateTime(2025, 2, 17, 14, 27, 43, 133, DateTimeKind.Local).AddTicks(5198), new DateTimeOffset(new DateTime(2025, 2, 17, 11, 27, 43, 133, DateTimeKind.Unspecified).AddTicks(5199), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 17, 14, 27, 43, 133, DateTimeKind.Local).AddTicks(5116), new DateTimeOffset(new DateTime(2025, 2, 17, 11, 27, 43, 133, DateTimeKind.Unspecified).AddTicks(5118), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDetails_BankBranches_BankBranchId",
                table: "EmployeeDetails",
                column: "BankBranchId",
                principalTable: "BankBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDetails_Banks_BankId",
                table: "EmployeeDetails",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
