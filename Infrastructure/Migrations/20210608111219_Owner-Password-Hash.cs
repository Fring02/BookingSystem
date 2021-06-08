using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class OwnerPasswordHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeisureServicesOwners",
                keyColumn: "Id",
                keyValue: new Guid("deaae489-eb20-45be-94ad-7c44a166ba22"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "LeisureServicesOwners");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "LeisureServicesOwners",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "LeisureServicesOwners",
                type: "bytea",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "LeisureServicesOwners");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "LeisureServicesOwners");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "LeisureServicesOwners",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "LeisureServicesOwners",
                columns: new[] { "Id", "Email", "Firstname", "Lastname", "MobilePhone", "Password" },
                values: new object[] { new Guid("deaae489-eb20-45be-94ad-7c44a166ba22"), "hasenovsultanbek@gmail.com", "Sultanbek", "Hasenov", "+7(776)-166-70-60", "qwerty123" });
        }
    }
}
