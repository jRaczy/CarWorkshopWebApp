using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarWorkshop.Models.ViewModels
{
    public class CarVM
    {
        public Car Car { get; set; }
        public IEnumerable<SelectListItem> SelectListItems{ get; set; }
    }
}
