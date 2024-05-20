using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRequestTracker.Migrations
{
    public partial class Create_request_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateOfRequest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfCompletion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RaisedBy = table.Column<int>(type: "int", nullable: false),
                    SolvedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Requests_Employees_RaisedBy",
                        column: x => x.RaisedBy,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Employees_SolvedBy",
                        column: x => x.SolvedBy,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RaisedBy",
                table: "Requests",
                column: "RaisedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_SolvedBy",
                table: "Requests",
                column: "SolvedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
