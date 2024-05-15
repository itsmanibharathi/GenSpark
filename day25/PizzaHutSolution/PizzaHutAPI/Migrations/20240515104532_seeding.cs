using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHutAPI.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Description", "Name", "Price", "QtyInHand", "status" },
                values: new object[] { 1, "Cheese and Tomato", "Margherita", 300m, 0, 1 });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Description", "Name", "Price", "QtyInHand", "status" },
                values: new object[] { 2, "Pepperoni and Cheese", "Pepperoni", 500m, 0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
