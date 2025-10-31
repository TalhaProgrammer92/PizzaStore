using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Pizzas_Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Pizzas",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<Guid>(
                name: "PizzaVarietyId",
                table: "Pizzas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Pizzas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PizzaVarieties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaVarieties", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_PizzaVarietyId",
                table: "Pizzas",
                column: "PizzaVarietyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_PizzaVarieties_PizzaVarietyId",
                table: "Pizzas",
                column: "PizzaVarietyId",
                principalTable: "PizzaVarieties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_PizzaVarieties_PizzaVarietyId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "PizzaVarieties");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_PizzaVarietyId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "PizzaVarietyId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Pizzas");
        }
    }
}
