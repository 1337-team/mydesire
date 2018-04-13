using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Wish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public int StatusId { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
        public int PerfomerId { get; set; }

        [ForeignKey("PerfomerId")]
        public User Perfomer { get; set; }

        //public virtual IEnumerable<User> PotentialPerformers { get; set; } = new List<User>();

        public Status Status { get; set; }
        //TODO: category/tag
    }


}

