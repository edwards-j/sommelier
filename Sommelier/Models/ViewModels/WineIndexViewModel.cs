using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sommelier.Models.ViewModels
{
    public class WineIndexViewModel
    {
        public Wine Wine { get; set; }

        public Winery Winery { get; set; }

        public Variety Variety { get; set; }
    }
}
