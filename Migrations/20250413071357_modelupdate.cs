using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class modelupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Camp_CampId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_AspNetUsers_UserId",
                table: "Stock");

            migrationBuilder.DropTable(
                name: "Camp");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CampId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CampId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Stock",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_UserId",
                table: "Stock",
                newName: "IX_Stock_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Order_OrderId",
                table: "Stock",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Order_OrderId",
                table: "Stock");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Stock",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_OrderId",
                table: "Stock",
                newName: "IX_Stock_UserId");

            migrationBuilder.AddColumn<int>(
                name: "CampId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Camp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    peoplelimt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camp", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CampId",
                table: "AspNetUsers",
                column: "CampId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Camp_CampId",
                table: "AspNetUsers",
                column: "CampId",
                principalTable: "Camp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_AspNetUsers_UserId",
                table: "Stock",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
