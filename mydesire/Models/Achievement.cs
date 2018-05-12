using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mydesire.Models
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double RatingToGain { get; set; }
        public virtual IEnumerable<UserAchievement> UserAchievements { get; set; }
    }
}
