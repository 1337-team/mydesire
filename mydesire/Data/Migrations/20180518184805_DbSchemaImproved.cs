using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace mydesire.Data.Migrations
{
    public partial class DbSchemaImproved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAchievements");

            migrationBuilder.AddColumn<string>(
                name: "IssuerId",
                table: "Wishes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserAchievements",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    AchievementId = table.Column<int>(nullable: false),
                    Progress = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserAchievements", x => new { x.ApplicationUserId, x.AchievementId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserAchievements_Achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserAchievements_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

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
                        name: "FK_WishCategories_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
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
                name: "IX_Wishes_IssuerId",
                table: "Wishes",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserAchievements_AchievementId",
                table: "ApplicationUserAchievements",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_WishCategories_CategoryId",
                table: "WishCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishes_AspNetUsers_IssuerId",
                table: "Wishes",
                column: "IssuerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishes_AspNetUsers_IssuerId",
                table: "Wishes");

            migrationBuilder.DropTable(
                name: "ApplicationUserAchievements");

            migrationBuilder.DropTable(
                name: "WishCategories");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Wishes_IssuerId",
                table: "Wishes");

            migrationBuilder.DropColumn(
                name: "IssuerId",
                table: "Wishes");

            migrationBuilder.CreateTable(
                name: "UserAchievements",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    AchievementId = table.Column<int>(nullable: false),
                    Progress = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAchievements", x => new { x.ApplicationUserId, x.AchievementId });
                    table.ForeignKey(
                        name: "FK_UserAchievements_Achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAchievements_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_AchievementId",
                table: "UserAchievements",
                column: "AchievementId");
        }
    }
}
