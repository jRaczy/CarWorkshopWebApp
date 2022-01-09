using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Controllers
{
    public class AddCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
