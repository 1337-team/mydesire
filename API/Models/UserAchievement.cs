using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class UserAchievement
    {
        public int UserId { get; set; }
        public int AchievementId { get; set; }
        public User User { get; set; }
        public Achievement Achievement { get; set; }
        public double Progress { get; set; }


    }
}