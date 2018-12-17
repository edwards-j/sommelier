using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sommelier.Models.ViewModels
{
    public class UpdateBottleCountViewModel
    {
        public CreateWineViewModel newWine { get; set; }

        public List<Wine> existingWine { get; set; }
    }
}
