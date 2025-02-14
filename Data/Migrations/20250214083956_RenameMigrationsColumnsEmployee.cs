using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameMigrationsColumnsEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_AspNetUsers_ApplicationUserId",
                table: "EmployeeDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EmployeeDetails");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "EmployeeDetails",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDetails_ApplicationUserId",
                table: "EmployeeDetails",
                newName: "IX_EmployeeDetails_EmployeeId");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 14, 11, 39, 56, 20, DateTimeKind.Local).AddTicks(7705), new DateTimeOffset(new DateTime(2025, 2, 14, 8, 39, 56, 20, DateTimeKind.Unspecified).AddTicks(7706), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 14, 11, 39, 56, 20, DateTimeKind.Local).AddTicks(7675), new DateTimeOffset(new DateTime(2025, 2, 14, 8, 39, 56, 20, DateTimeKind.Unspecified).AddTicks(7676), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDetails_AspNetUsers_EmployeeId",
                table: "EmployeeDetails",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_AspNetUsers_EmployeeId",
                table: "EmployeeDetails");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "EmployeeDetails",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDetails_EmployeeId",
                table: "EmployeeDetails",
                newName: "IX_EmployeeDetails_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "EmployeeDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 14, 11, 36, 15, 268, DateTimeKind.Local).AddTicks(7419), new DateTimeOffset(new DateTime(2025, 2, 14, 8, 36, 15, 268, DateTimeKind.Unspecified).AddTicks(7419), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 14, 11, 36, 15, 268, DateTimeKind.Local).AddTicks(7391), new DateTimeOffset(new DateTime(2025, 2, 14, 8, 36, 15, 268, DateTimeKind.Unspecified).AddTicks(7393), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDetails_AspNetUsers_ApplicationUserId",
                table: "EmployeeDetails",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
