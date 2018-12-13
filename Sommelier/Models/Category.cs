using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sommelier.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<FoodCategory> FoodCategory { get; set; }

        public virtual List<Variety> Varieties { get; set; }
    }
}
