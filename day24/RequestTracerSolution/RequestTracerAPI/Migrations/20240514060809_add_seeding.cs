using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTracerAPI.Migrations
{
    public partial class add_seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "Name", "PhoneNumber" },
                values: new object[] { 101, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mani", "1234567890" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "Name", "PhoneNumber" },
                values: new object[] { 102, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiko", "9876543210" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102);
        }
    }
}
