using CarWorkshop.Data;
using CarWorkshop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Controllers
{
    public class CarListController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CarListController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(Client client)
        {
            IEnumerable<Car> objList = _db.Car.Where(x => x.Client ==client);
            return View(objList);
        }
    }
}
