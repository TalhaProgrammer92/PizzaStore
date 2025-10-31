using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ServicesInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "PizzaVarieties");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "PizzaVarieties",
                type: "int",
                nullable: true);
        }
    }
}
