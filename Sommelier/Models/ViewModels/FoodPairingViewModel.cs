using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sommelier.Models.ViewModels
{
    public class FoodPairingViewModel
    {
        public string FoodCategories { get; set; }

        public List<Wine> Wines { get; set; }

        public Food Food { get; set; }
    }
}
