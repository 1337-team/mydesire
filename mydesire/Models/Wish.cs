using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mydesire.Models
{
    public class Wish
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Изображение")]
        public byte[] Photo { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата создания")]
        public DateTime OpenDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата завершения")]
        public DateTime CloseDate { get; set; }
        public int StatusId { get; set; }
        [Display(Name = "Комментарии")]
        public IEnumerable<Comment> Comments { get; set; }
        public string PerfomerId { get; set; }

        [ForeignKey("PerfomerId")]
        [Display(Name = "Исполнитель")]
        public ApplicationUser Perfomer { get; set; }

        public string IssuerId { get; set; }

        [ForeignKey("IssuerId")]
        [Display(Name = "Создатель")]
        public ApplicationUser Issuer { get; set; }

        public IEnumerable<WishCategory> WishCategories { get; set; }

        //public virtual IEnumerable<ApplicationUser> PotentialPerformers { get; set; } = new List<ApplicationUser>();

        [Display(Name = "Статус")]
        public Status Status { get; set; }
    }
}
