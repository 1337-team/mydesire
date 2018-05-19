using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace mydesire.Data.Migrations
{
    public partial class WishCategory1Many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WishCategories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Wishes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Wishes_CategoryId",
                table: "Wishes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishes_Categories_CategoryId",
                table: "Wishes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishes_Categories_CategoryId",
                table: "Wishes");

            migrationBuilder.DropIndex(
                name: "IX_Wishes_CategoryId",
                table: "Wishes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Wishes");

            migrationBuilder.CreateTable(
                name: "WishCategories",
                columns: table => new
                {
                    WishId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishCategories", x => new { x.WishId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_WishCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishCategories_Wishes_WishId",
                        column: x => x.WishId,
                        principalTable: "Wishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WishCategories_CategoryId",
                table: "WishCategories",
                column: "CategoryId");
        }
    }
}
