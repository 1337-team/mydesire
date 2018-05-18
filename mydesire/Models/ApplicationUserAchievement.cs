using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mydesire.Models
{
    public class ApplicationUserAchievement
    {
        public string ApplicationUserId { get; set; }
        public int AchievementId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Achievement Achievement { get; set; }
        public double Progress { get; set; }
    }
}
