using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mydesire.Models
{
    public class WishCategory
    {
        public int WishId { get; set; }
        public int CategoryId { get; set; }
        public Wish Wish { get; set; }
        public Category Category { get; set; }
    }
}
