using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerModelLibrary.Migrations
{
    public partial class Add_seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Password", "Role" },
                values: new object[] { 101, "Mani", "123", 0 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Password", "Role" },
                values: new object[] { 102, "kiko", "123", 2 });
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
