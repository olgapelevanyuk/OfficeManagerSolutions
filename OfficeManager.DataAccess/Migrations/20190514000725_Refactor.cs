using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeManager.DataAccess.Migrations
{
    public partial class Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthdate", "Created", "Updated" },
                values: new object[] { new DateTime(2019, 5, 14, 0, 7, 22, 481, DateTimeKind.Utc).AddTicks(6694), new DateTime(2019, 5, 14, 0, 7, 22, 482, DateTimeKind.Utc).AddTicks(656), new DateTime(2019, 5, 14, 0, 7, 22, 482, DateTimeKind.Utc).AddTicks(1672) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthdate", "Created", "Updated" },
                values: new object[] { new DateTime(2019, 5, 13, 23, 12, 55, 933, DateTimeKind.Utc).AddTicks(4378), new DateTime(2019, 5, 13, 23, 12, 55, 934, DateTimeKind.Utc).AddTicks(182), new DateTime(2019, 5, 13, 23, 12, 55, 934, DateTimeKind.Utc).AddTicks(1680) });
        }
    }
}
