using CarWorkshop.Data;
using CarWorkshop.Models;
using CarWorkshop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Controllers
{
    public class AddCarController : Controller
    {
        int clientId;
            private readonly ApplicationDbContext _db;
            public AddCarController(ApplicationDbContext db)
            {
                _db = db;
            }
            public IActionResult Index()
            {
          
                return View();
            }
        public IActionResult Create(Client client)
        {
            CarVM carVM = new CarVM()
            {
                Car = new Car(),
                SelectListItems = _db.Client.Select(i => new SelectListItem
                {
                    Value = i.Id.ToString()
                })
               
            };
            carVM.Car.Client = client;
            carVM.Car.ClientId = client.Id;
            return View(carVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarVM obj)

        {
            var client = _db.Client.Include(x => x.Cars).FirstOrDefault(x => x.Id == obj.Car.ClientId);
            //obj.Car.Client = client;
            _db.Car.Add(obj.Car);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
