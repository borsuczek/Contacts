using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contacts.Api.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    type = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.type);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subcategory_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birth_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.name);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                column: "type",
                values: new object[]
                {
                    "inny",
                    "służbowy",
                    "prywatny"
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Email", "Birth_date", "Category_type", "Name", "Password", "Phone", "Subcategory_name", "Surname" },
                values: new object[,]
                {
                    { "basic@gmail.com", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "inny", "Piotr", "Pi0trek%", "222333444", "brak", "Nowak" },
                    { "basic2@gmail.com", new DateTime(1980, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "inny", "Anna", "Kowal123", "184726334", "brak", "Kowalska" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                column: "name",
                values: new object[]
                {
                    "brak",
                    "szef",
                    "pracownik",
                    "klient"
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Subcategories");
        }
    }
}
