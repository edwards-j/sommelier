using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sommelier.Models
{
    public class FoodCategory
    {
        [Key]
        public int FoodCategoryId { get; set; }

        public int FoodId { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
