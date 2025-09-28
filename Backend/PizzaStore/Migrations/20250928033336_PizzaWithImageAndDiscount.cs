using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaStore.Migrations
{
    /// <inheritdoc />
    public partial class PizzaWithImageAndDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Pizzas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "Pizzas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Pizzas",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Pizzas");
        }
    }
}
