using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mydesire.Models;

namespace mydesire.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Wish> Wishes { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ApplicationUserAchievement> ApplicationUserAchievements { get; set; }
        public DbSet<WishCategory> WishCategories { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            
            // Формирование отношения многие-ко-многим между User и Achievement
            builder.Entity<ApplicationUserAchievement>()
                .HasKey(ua => new { ua.ApplicationUserId, ua.AchievementId });

            builder.Entity<ApplicationUserAchievement>()
                .HasOne(ua => ua.ApplicationUser)
                .WithMany(u => u.ApplicationUserAchievements)
                .HasForeignKey(ua => ua.ApplicationUserId);

            builder.Entity<ApplicationUserAchievement>()
                .HasOne(ua => ua.Achievement)
                .WithMany(a => a.ApplicationUserAchievements)
                .HasForeignKey(ua => ua.AchievementId);

            // Формирование отношения многие-ко-многим между Wish и Category
            builder.Entity<WishCategory>()
               .HasKey(wc => new { wc.WishId, wc.CategoryId });

            builder.Entity<WishCategory>()
                .HasOne(wc => wc.Wish)
                .WithMany(w => w.WishCategories)
                .HasForeignKey(wc => wc.WishId);

            builder.Entity<WishCategory>()
                .HasOne(wc => wc.Category)
                .WithMany(c => c.WishCategories)
                .HasForeignKey(wc => wc.CategoryId);

            // Формирование отношения вручную между Wish и User, т.к. несколько навигационных свойств
            builder.Entity<Wish>()
                .HasOne(w => w.Issuer)
                .WithMany(au => au.MyWishes)
                .HasForeignKey(w => w.IssuerId);

            builder.Entity<Wish>()
                .HasOne(w => w.Perfomer)
                .WithMany(au => au.MyWishesToPerform)
                .HasForeignKey(w => w.PerfomerId);


        }
    }
}
