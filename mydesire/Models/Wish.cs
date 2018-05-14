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
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        [DataType(DataType.Date)]
        public DateTime OpenDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime CloseDate { get; set; }
        public int StatusId { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
        public string PerfomerId { get; set; }

        [ForeignKey("PerfomerId")]
        public ApplicationUser Perfomer { get; set; }

        //public virtual IEnumerable<ApplicationUser> PotentialPerformers { get; set; } = new List<ApplicationUser>();

        public Status Status { get; set; }
    }
}
