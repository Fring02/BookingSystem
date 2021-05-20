using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddRatedCountForServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeisureServicesOwners",
                keyColumn: "Id",
                keyValue: new Guid("e190d168-2520-41a4-a8ae-25735dfa2fb0"));

            migrationBuilder.AddColumn<int>(
                name: "RatedCount",
                table: "LeisureServices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "LeisureServicesOwners",
                columns: new[] { "Id", "Email", "Firstname", "Lastname", "MobilePhone", "Password" },
                values: new object[] { new Guid("3fab1933-b8fb-4d45-9718-b3b8694b0fc7"), "hasenovsultanbek@gmail.com", "Sultanbek", "Hasenov", "+7(776)-166-70-60", "qwerty123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeisureServicesOwners",
                keyColumn: "Id",
                keyValue: new Guid("3fab1933-b8fb-4d45-9718-b3b8694b0fc7"));

            migrationBuilder.DropColumn(
                name: "RatedCount",
                table: "LeisureServices");

            migrationBuilder.InsertData(
                table: "LeisureServicesOwners",
                columns: new[] { "Id", "Email", "Firstname", "Lastname", "MobilePhone", "Password" },
                values: new object[] { new Guid("e190d168-2520-41a4-a8ae-25735dfa2fb0"), "hasenovsultanbek@gmail.com", "Sultanbek", "Hasenov", "+7(776)-166-70-60", "qwerty123" });
        }
    }
}
