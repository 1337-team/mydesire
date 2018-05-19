using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mydesire.Models
{
    public class Achievement
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Награда (кол-во очков)")]
        public double RatingToGain { get; set; }
        public virtual IEnumerable<ApplicationUserAchievement> ApplicationUserAchievements { get; set; }
    }
}
