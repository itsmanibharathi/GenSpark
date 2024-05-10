using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerModelLibrary.Migrations
{
    public partial class Add_requstSolution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RequestClosedBy",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ClosedDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestStatus",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "RequestClosedBy",
                table: "Requests",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "RequestNumber",
                table: "Requests",
                newName: "RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_RequestClosedBy",
                table: "Requests",
                newName: "IX_Requests_EmployeeId");

            migrationBuilder.AlterColumn<string>(
                name: "RequestMessage",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequestClosed",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "RequestSolutions",
                columns: table => new
                {
                    SolutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    SolutionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolvedBy = table.Column<int>(type: "int", nullable: false),
                    SolvedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSolved = table.Column<bool>(type: "bit", nullable: false),
                    RequestRaiserComment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSolutions", x => x.SolutionId);
                    table.ForeignKey(
                        name: "FK_RequestSolutions_Employees_SolvedBy",
                        column: x => x.SolvedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestSolutions_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestSolutions_RequestId",
                table: "RequestSolutions",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSolutions_SolvedBy",
                table: "RequestSolutions",
                column: "SolvedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_EmployeeId",
                table: "Requests",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_EmployeeId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "RequestSolutions");

            migrationBuilder.DropColumn(
                name: "IsRequestClosed",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Requests",
                newName: "RequestClosedBy");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "Requests",
                newName: "RequestNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_EmployeeId",
                table: "Requests",
                newName: "IX_Requests_RequestClosedBy");

            migrationBuilder.AlterColumn<string>(
                name: "RequestMessage",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedDate",
                table: "Requests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestStatus",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

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
