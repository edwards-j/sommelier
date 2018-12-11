using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sommelier.Models
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }

        public string Name { get; set; }
    }
}
