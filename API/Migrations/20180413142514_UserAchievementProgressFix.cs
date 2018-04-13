using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace API.Migrations
{
    public partial class UserAchievementProgressFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Progress",
                table: "Achievement");

            migrationBuilder.AddColumn<double>(
                name: "Progress",
                table: "UserAchievement",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Progress",
                table: "UserAchievement");

            migrationBuilder.AddColumn<double>(
                name: "Progress",
                table: "Achievement",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
