using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerModelLibrary.Migrations
{
    public partial class remove_reqclose : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RequestClosedBy",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestClosedBy",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestClosedBy",
                table: "Requests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestClosedBy",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestClosedBy",
                table: "Requests",
                column: "RequestClosedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RequestClosedBy",
                table: "Requests",
                column: "RequestClosedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
