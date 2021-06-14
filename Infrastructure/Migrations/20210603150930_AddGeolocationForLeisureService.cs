using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddGeolocationForLeisureService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "LeisureServices",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "LeisureServices",
                type: "double precision",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeisureServicesOwners",
                keyColumn: "Id",
                keyValue: new Guid("81a80284-e72c-4a29-ace5-ece125e555ff"));

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "LeisureServices");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "LeisureServices");

            migrationBuilder.InsertData(
                table: "LeisureServicesOwners",
                columns: new[] { "Id", "Email", "Firstname", "Lastname", "MobilePhone", "Password", "Role" },
                values: new object[] { new Guid("00f31f27-dd0d-4538-8dcd-fddddd76c68d"), "hasenovsultanbek@gmail.com", "Sultanbek", "Hasenov", "+7(776)-166-70-60", "qwerty123", "ADMIN" });
        }
    }
}
