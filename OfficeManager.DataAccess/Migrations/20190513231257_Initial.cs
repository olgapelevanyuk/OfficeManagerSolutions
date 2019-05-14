using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeManager.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    PassportSerialNumber = table.Column<string>(nullable: true),
                    PassportNumber = table.Column<string>(nullable: true),
                    RegistrationCity = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Adderss = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Adderss", "Birthdate", "City", "Created", "Firstname", "IsDeleted", "Lastname", "MobilePhone", "Nationality", "PassportNumber", "PassportSerialNumber", "RegistrationCity", "Updated" },
                values: new object[] { 1, "Test city,Test street,Test home", new DateTime(2019, 5, 13, 23, 12, 55, 933, DateTimeKind.Utc).AddTicks(4378), "Test city", new DateTime(2019, 5, 13, 23, 12, 55, 934, DateTimeKind.Utc).AddTicks(182), "Test", false, "Test", "+375291111111", "Belarus", "112233", "AB", "Test registration city", new DateTime(2019, 5, 13, 23, 12, 55, 934, DateTimeKind.Utc).AddTicks(1680) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
