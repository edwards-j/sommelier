using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sommelier.Models
{
    public class Variety
    {
        [Key]
        public int VarietyId { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        //public virtual Wine Wine { get; set; }

          
        public virtual ICollection<Wine> Wines { get; set;}
    }
}
