using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfJoin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "ID", "DateOfJoin", "Name", "Specialization" },
                values: new object[] { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Mani", "General Physician" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "ID", "DateOfJoin", "Name", "Specialization" },
                values: new object[] { 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Kiko", "Dentist" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
