using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sommelier.Models.ViewModels
{
    public class CreateWineViewModel
    {
       public Wine Wine { get; set; }

       public Winery Winery { get; set; }

       public List<SelectListItem> Wineries { get; set; }

       public List<SelectListItem> Varieties { get; set; }

       public ApplicationUser User { get; set; }
    }
}
