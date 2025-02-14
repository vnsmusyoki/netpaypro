using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc /> 
    public partial class UpdatingEmployeeDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_AspNetUsers_ApplicationUserId",
                table: "EmployeeDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "EmployeeDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "EmployeeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "EmployeeDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 14, 11, 27, 55, 428, DateTimeKind.Local).AddTicks(3609), new DateTimeOffset(new DateTime(2025, 2, 14, 8, 27, 55, 428, DateTimeKind.Unspecified).AddTicks(3609), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 14, 11, 27, 55, 428, DateTimeKind.Local).AddTicks(3583), new DateTimeOffset(new DateTime(2025, 2, 14, 8, 27, 55, 428, DateTimeKind.Unspecified).AddTicks(3584), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_CompanyId",
                table: "EmployeeDetails",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDetails_AspNetUsers_ApplicationUserId",
                table: "EmployeeDetails",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDetails_Companies_CompanyId",
                table: "EmployeeDetails",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_AspNetUsers_ApplicationUserId",
                table: "EmployeeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_Companies_CompanyId",
                table: "EmployeeDetails");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDetails_CompanyId",
                table: "EmployeeDetails");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "EmployeeDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EmployeeDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "EmployeeDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 13, 11, 51, 53, 72, DateTimeKind.Local).AddTicks(3884), new DateTimeOffset(new DateTime(2025, 2, 13, 8, 51, 53, 72, DateTimeKind.Unspecified).AddTicks(3885), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 13, 11, 51, 53, 72, DateTimeKind.Local).AddTicks(3827), new DateTimeOffset(new DateTime(2025, 2, 13, 8, 51, 53, 72, DateTimeKind.Unspecified).AddTicks(3829), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDetails_AspNetUsers_ApplicationUserId",
                table: "EmployeeDetails",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
