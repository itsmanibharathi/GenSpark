using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerModelLibrary.Migrations
{
    public partial class Add_solution_Feedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_EmployeeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolutions_Requests_RequestId",
                table: "RequestSolutions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_EmployeeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IsRequestClosed",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "Requests",
                newName: "RequestClosedBy");

            migrationBuilder.AlterColumn<int>(
                name: "RequestClosedBy",
                table: "Requests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RequestNumber",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedDate",
                table: "Requests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestStatus",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "RequestNumber");

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionId = table.Column<int>(type: "int", nullable: false),
                    FeedbackBy = table.Column<int>(type: "int", nullable: false),
                    FeedbackDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Employees_FeedbackBy",
                        column: x => x.FeedbackBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_RequestSolutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "RequestSolutions",
                        principalColumn: "SolutionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestClosedBy",
                table: "Requests",
                column: "RequestClosedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackBy",
                table: "Feedbacks",
                column: "FeedbackBy");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_SolutionId",
                table: "Feedbacks",
                column: "SolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RequestClosedBy",
                table: "Requests",
                column: "RequestClosedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolutions_Requests_RequestId",
                table: "RequestSolutions",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RequestClosedBy",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolutions_Requests_RequestId",
                table: "RequestSolutions");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestClosedBy",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestNumber",
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
                newName: "RequestId");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "Requests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequestClosed",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_EmployeeId",
                table: "Requests",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_EmployeeId",
                table: "Requests",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolutions_Requests_RequestId",
                table: "RequestSolutions",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
