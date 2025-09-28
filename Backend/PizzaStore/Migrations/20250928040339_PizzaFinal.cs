using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaStore.Migrations
{
    /// <inheritdoc />
    public partial class PizzaFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Pizzas");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Pizzas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Pizzas");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Pizzas",
                type: "datetime2",
                nullable: true);
        }
    }
}
