using System.Collections.Generic;

namespace API.Models
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double RatingToGain { get; set; }
        public virtual IEnumerable<UserAchievement> UserAchievements { get; set; }

    }
}