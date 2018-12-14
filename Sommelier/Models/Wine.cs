using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sommelier.Models
{
    public class Wine
    {
        [Key]
        public int WineId {get; set;}

        public string Name { get; set; }

        [Display(Name ="Winery")]          
        public int WineryId { get; set; }

        [Display(Name = "Variety")]
        public int VarietyId { get; set; }

        public int Year { get; set; }

        public string ApplicationUserId { get; set; }

        public bool Favorite { get; set; }

        [Display(Name = "Bottles")]
        public int Quantity { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        
        
        public virtual Winery Winery { get; set; }
        
        public virtual Variety Variety { get; set; }
    }
}
