using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class size : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClothingSizes",
                table: "Stock",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoeSizes",
                table: "Stock",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClothingSizes",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "ShoeSizes",
                table: "Stock");
        }
    }
}
