using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddInfoForBookingRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeisureServicesOwners",
                keyColumn: "Id",
                keyValue: new Guid("ab44cb7a-97f4-4004-b2df-78c33f3fb13c"));

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "BookingRequests",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "LeisureServicesOwners",
                columns: new[] { "Id", "Email", "Firstname", "Lastname", "MobilePhone", "Password" },
                values: new object[] { new Guid("e190d168-2520-41a4-a8ae-25735dfa2fb0"), "hasenovsultanbek@gmail.com", "Sultanbek", "Hasenov", "+7(776)-166-70-60", "qwerty123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeisureServicesOwners",
                keyColumn: "Id",
                keyValue: new Guid("e190d168-2520-41a4-a8ae-25735dfa2fb0"));

            migrationBuilder.DropColumn(
                name: "Info",
                table: "BookingRequests");

            migrationBuilder.InsertData(
                table: "LeisureServicesOwners",
                columns: new[] { "Id", "Email", "Firstname", "Lastname", "MobilePhone", "Password" },
                values: new object[] { new Guid("ab44cb7a-97f4-4004-b2df-78c33f3fb13c"), "hasenovsultanbek@gmail.com", "Sultanbek", "Hasenov", "+7(776)-166-70-60", "qwerty123" });
        }
    }
}
