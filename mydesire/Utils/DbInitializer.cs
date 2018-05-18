using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mydesire.Data;
using mydesire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mydesire.Utils
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            await InitializeRolesAsync(userManager, roleManager);
            await InitializeStatusesAsync(context);
            
            
        }

        public static async Task InitializeRolesAsync(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "qwerty123";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                ApplicationUser admin = new ApplicationUser { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }

        public static async Task InitializeStatusesAsync(ApplicationDbContext context)
        {
            var mandatoryStatuses = new List<Status>
            {
                new Status { Name = "Выполнено"},
                new Status { Name = "Выполняется"},
                new Status { Name = "Ожидает исполнителя"},
                new Status { Name = "Не выполнено"}
            };

            foreach (var status in mandatoryStatuses)
            {
                if (await context.Statuses.Where(s => s.Name == status.Name).SingleOrDefaultAsync() == null)
                {
                    await context.AddAsync(status);
                }
            }
            await context.SaveChangesAsync();
        }
    }
}
