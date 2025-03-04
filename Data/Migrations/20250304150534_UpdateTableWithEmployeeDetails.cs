using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableWithEmployeeDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
        IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
                       WHERE TABLE_NAME = 'EmployeeDetails' 
                       AND COLUMN_NAME = 'BankBranchId')
        BEGIN
            ALTER TABLE EmployeeDetails ADD BankBranchId INT NULL;
        END
    ");

            migrationBuilder.Sql(@"
        IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'BankBranches')
        BEGIN
            IF NOT EXISTS (
                SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
                WHERE TABLE_NAME = 'EmployeeDetails' 
                AND CONSTRAINT_NAME = 'FK_EmployeeDetails_BankBranches_BankBranchId')
            BEGIN
                ALTER TABLE EmployeeDetails 
                ADD CONSTRAINT FK_EmployeeDetails_BankBranches_BankBranchId 
                FOREIGN KEY (BankBranchId) 
                REFERENCES BankBranches(Id);
            END
        END
    ");



            migrationBuilder.AddColumn<string>(
               name: "OtherEmployeeDetails",
               table: "EmployeeDetails",
               type: "nvarchar(max)",
               nullable: true);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 18, 5, 31, 298, DateTimeKind.Local).AddTicks(9724), new DateTimeOffset(new DateTime(2025, 3, 4, 15, 5, 31, 298, DateTimeKind.Unspecified).AddTicks(9726), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 18, 5, 31, 298, DateTimeKind.Local).AddTicks(9620), new DateTimeOffset(new DateTime(2025, 3, 4, 15, 5, 31, 298, DateTimeKind.Unspecified).AddTicks(9621), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherEmployeeDetails",
                table: "EmployeeDetails");

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
        }
    }
}
