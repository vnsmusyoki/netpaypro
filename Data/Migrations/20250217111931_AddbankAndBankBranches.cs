using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddbankAndBankBranches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountNo",
                table: "EmployeeDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BankBranchId",
                table: "EmployeeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "EmployeeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<int>(type: "int", nullable: false),
                    BankCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SwiftCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankBranches_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 17, 14, 19, 27, 554, DateTimeKind.Local).AddTicks(2543), new DateTimeOffset(new DateTime(2025, 2, 17, 11, 19, 27, 554, DateTimeKind.Unspecified).AddTicks(2546), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 17, 14, 19, 27, 554, DateTimeKind.Local).AddTicks(2299), new DateTimeOffset(new DateTime(2025, 2, 17, 11, 19, 27, 554, DateTimeKind.Unspecified).AddTicks(2302), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_BankBranchId",
                table: "EmployeeDetails",
                column: "BankBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_BankId",
                table: "EmployeeDetails",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankBranches_BankId",
                table: "BankBranches",
                column: "BankId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_BankBranches_BankBranchId",
                table: "EmployeeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_Banks_BankId",
                table: "EmployeeDetails");

            migrationBuilder.DropTable(
                name: "BankBranches");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDetails_BankBranchId",
                table: "EmployeeDetails");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDetails_BankId",
                table: "EmployeeDetails");

            migrationBuilder.DropColumn(
                name: "AccountNo",
                table: "EmployeeDetails");

            migrationBuilder.DropColumn(
                name: "BankBranchId",
                table: "EmployeeDetails");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "EmployeeDetails");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 16, 18, 35, 36, 251, DateTimeKind.Local).AddTicks(8876), new DateTimeOffset(new DateTime(2025, 2, 16, 15, 35, 36, 251, DateTimeKind.Unspecified).AddTicks(8877), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 16, 18, 35, 36, 251, DateTimeKind.Local).AddTicks(8843), new DateTimeOffset(new DateTime(2025, 2, 16, 15, 35, 36, 251, DateTimeKind.Unspecified).AddTicks(8844), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
