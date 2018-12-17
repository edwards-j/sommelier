using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sommelier.Models.ViewModels
{
    public class WineDetailsViewModel
    {
        public Wine Wine { get; set; }

        public string FoodCategories { get; set; }

        public List<Food> Foods { get; set; }
    }
}
