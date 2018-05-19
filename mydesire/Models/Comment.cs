using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mydesire.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Текст")]
        public string Text { get; set; }

    }
}
