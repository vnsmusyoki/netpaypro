using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PinNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNo = table.Column<int>(type: "int", nullable: false),
                    NssfNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhifNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShaNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasicPay = table.Column<int>(type: "int", nullable: false),
                    HouseAllowance = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDetails_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_ApplicationUserId",
                table: "EmployeeDetails",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDetails");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 13, 11, 46, 20, 143, DateTimeKind.Local).AddTicks(8621), new DateTimeOffset(new DateTime(2025, 2, 13, 8, 46, 20, 143, DateTimeKind.Unspecified).AddTicks(8622), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 13, 11, 46, 20, 143, DateTimeKind.Local).AddTicks(8563), new DateTimeOffset(new DateTime(2025, 2, 13, 8, 46, 20, 143, DateTimeKind.Unspecified).AddTicks(8565), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
