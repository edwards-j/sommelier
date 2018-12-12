using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sommelier.Models
{
    public class Wine
    {
        [Key]
        public int WineId {get; set;}

        public string Name { get; set; }

        public int WineryId { get; set; }

        public int VarietyId { get; set; }

        public int Year { get; set; }

        public string ApplicationUserId { get; set; }

        public bool Favorite { get; set; }

        public int Quantity { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
