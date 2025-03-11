

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class CampSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    peoplelimt = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Camp_CampId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Camp");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CampId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CampId",
                table: "AspNetUsers");
        }
    }
}
