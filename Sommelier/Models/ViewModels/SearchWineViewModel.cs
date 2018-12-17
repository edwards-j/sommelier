using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sommelier.Models.ViewModels
{
    public class SearchWineViewModel
    {
        public List<Wine> Wines { get; set; }

        public string searchTerm { get; set; }
    }
}
