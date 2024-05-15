using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAPI.Migrations
{
    public partial class updatedoctor_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Designation", "Experience" },
                values: new object[] { "Senior Doctor", 5 });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Designation", "Experience" },
                values: new object[] { "Junior Doctor", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Doctors");
        }
    }
}
