using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sommelier.Models
{
    public class UserWine
    {
        [Key]
        public int UserWineId { get; set; }

        public int UserId { get; set; }

        public int WineId { get; set; }

        public bool Favorite { get; set; }
    }
}
