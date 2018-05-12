﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace mydesire.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Rating { get; set; }
        public virtual IEnumerable<UserAchievement> UserAchievements { get; set; }
        public virtual IEnumerable<Wish> Wishes { get; set; }
        public byte[] Photo { get; set; }
        public string About { get; set; }
    }
}
