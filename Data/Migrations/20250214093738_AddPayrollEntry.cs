using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netpaypro.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPayrollEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayrollEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BasicPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HousingAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherAllowances = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IncomeTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PAYERelief = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SHIFRelief = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AHLRelief = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PAYE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NSSF = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RBAPension = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SHIF = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HousingLevy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAdvances = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NettPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayrollMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayrollYear = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollEntries_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollEntries_Companies_CompanyId",
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
                values: new object[] { new DateTime(2025, 2, 14, 12, 37, 34, 972, DateTimeKind.Local).AddTicks(9941), new DateTimeOffset(new DateTime(2025, 2, 14, 9, 37, 34, 972, DateTimeKind.Unspecified).AddTicks(9947), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 14, 12, 37, 34, 972, DateTimeKind.Local).AddTicks(9608), new DateTimeOffset(new DateTime(2025, 2, 14, 9, 37, 34, 972, DateTimeKind.Unspecified).AddTicks(9613), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_PayrollEntries_CompanyId",
                table: "PayrollEntries",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollEntries_EmployeeId",
                table: "PayrollEntries",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayrollEntries");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 14, 11, 49, 18, 584, DateTimeKind.Local).AddTicks(6944), new DateTimeOffset(new DateTime(2025, 2, 14, 8, 49, 18, 584, DateTimeKind.Unspecified).AddTicks(6944), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 14, 11, 49, 18, 584, DateTimeKind.Local).AddTicks(6917), new DateTimeOffset(new DateTime(2025, 2, 14, 8, 49, 18, 584, DateTimeKind.Unspecified).AddTicks(6917), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
