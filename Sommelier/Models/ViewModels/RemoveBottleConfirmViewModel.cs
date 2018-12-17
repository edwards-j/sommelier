using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sommelier.Models.ViewModels
{
    public class RemoveBottleConfirmViewModel
    {
        public Wine Wine { get; set; }

        public int RouteId { get; set; }
    }
}
