using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace mydesire.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Рейтинг")]
        public double Rating { get; set; }
        public IEnumerable<ApplicationUserAchievement> ApplicationUserAchievements { get; set; }
        [Display(Name = "Желания")]
        public IEnumerable<Wish> MyWishes { get; set; }
        [Display(Name = "Исполняемые мной желания")]
        public IEnumerable<Wish> MyWishesToPerform { get; set; }
        [Display(Name = "Фото")]
        public byte[] Photo { get; set; }
        [Display(Name = "О себе")]
        public string About { get; set; }
    }
}
