using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ChangeRoleForUserOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeisureServicesOwners",
                keyColumn: "Id",
                keyValue: new Guid("deaae489-eb20-45be-94ad-7c44a166ba22"));

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "LeisureServicesOwners",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "LeisureServicesOwners",
                columns: new[] { "Id", "Email", "Firstname", "Lastname", "MobilePhone", "Password", "Role" },
                values: new object[] { new Guid("00f31f27-dd0d-4538-8dcd-fddddd76c68d"), "hasenovsultanbek@gmail.com", "Sultanbek", "Hasenov", "+7(776)-166-70-60", "qwerty123", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeisureServicesOwners",
                keyColumn: "Id",
                keyValue: new Guid("00f31f27-dd0d-4538-8dcd-fddddd76c68d"));

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "LeisureServicesOwners");

            migrationBuilder.InsertData(
                table: "LeisureServicesOwners",
                columns: new[] { "Id", "Email", "Firstname", "Lastname", "MobilePhone", "Password" },
                values: new object[] { new Guid("deaae489-eb20-45be-94ad-7c44a166ba22"), "hasenovsultanbek@gmail.com", "Sultanbek", "Hasenov", "+7(776)-166-70-60", "qwerty123" });
        }
    }
}
