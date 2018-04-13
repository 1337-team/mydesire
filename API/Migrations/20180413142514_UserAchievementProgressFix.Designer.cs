﻿// <auto-generated />
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace API.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20180413142514_UserAchievementProgressFix")]
    partial class UserAchievementProgressFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Models.Achievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<double>("RatingToGain");

                    b.HasKey("Id");

                    b.ToTable("Achievement");
                });

            modelBuilder.Entity("API.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Text");

                    b.Property<int?>("WishId");

                    b.HasKey("Id");

                    b.HasIndex("WishId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("API.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("Photo");

                    b.Property<double>("Rating");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Models.UserAchievement", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("AchievementId");

                    b.Property<double>("Progress");

                    b.HasKey("UserId", "AchievementId");

                    b.HasIndex("AchievementId");

                    b.ToTable("UserAchievement");
                });

            modelBuilder.Entity("API.Models.Wish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CloseDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<DateTime>("OpenDate");

                    b.Property<int>("PerfomerId");

                    b.Property<byte[]>("Photo");

                    b.Property<int>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("PerfomerId");

                    b.HasIndex("StatusId");

                    b.ToTable("Wish");
                });

            modelBuilder.Entity("API.Models.Comment", b =>
                {
                    b.HasOne("API.Models.Wish")
                        .WithMany("Comments")
                        .HasForeignKey("WishId");
                });

            modelBuilder.Entity("API.Models.UserAchievement", b =>
                {
                    b.HasOne("API.Models.Achievement", "Achievement")
                        .WithMany("UserAchievements")
                        .HasForeignKey("AchievementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Models.User", "User")
                        .WithMany("UserAchievements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.Models.Wish", b =>
                {
                    b.HasOne("API.Models.User", "Perfomer")
                        .WithMany("Wishes")
                        .HasForeignKey("PerfomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
