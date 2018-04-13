using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public double Rating { get; set; }
        public virtual IEnumerable<UserAchievement> UserAchievements { get; set; }
        public virtual IEnumerable<Wish> Wishes { get; set; }
        public byte[] Photo { get; set; }
        public string About { get; set; }       
        
    }
}
