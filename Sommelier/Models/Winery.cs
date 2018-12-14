using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sommelier.Models
{
    public class Winery
    {
        [Key]
        public int WineryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Wine> Wines { get; set; }
    }
}
