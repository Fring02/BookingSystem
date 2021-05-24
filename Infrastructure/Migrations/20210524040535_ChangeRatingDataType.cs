using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ChangeRatingDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeisureServicesOwners",
                keyColumn: "Id",
                keyValue: new Guid("3fab1933-b8fb-4d45-9718-b3b8694b0fc7"));

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "LeisureServices",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "LeisureServicesOwners",
                columns: new[] { "Id", "Email", "Firstname", "Lastname", "MobilePhone", "Password" },
                values: new object[] { new Guid("deaae489-eb20-45be-94ad-7c44a166ba22"), "hasenovsultanbek@gmail.com", "Sultanbek", "Hasenov", "+7(776)-166-70-60", "qwerty123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeisureServicesOwners",
                keyColumn: "Id",
                keyValue: new Guid("deaae489-eb20-45be-94ad-7c44a166ba22"));

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "LeisureServices",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.InsertData(
                table: "LeisureServicesOwners",
                columns: new[] { "Id", "Email", "Firstname", "Lastname", "MobilePhone", "Password" },
                values: new object[] { new Guid("3fab1933-b8fb-4d45-9718-b3b8694b0fc7"), "hasenovsultanbek@gmail.com", "Sultanbek", "Hasenov", "+7(776)-166-70-60", "qwerty123" });
        }
    }
}
