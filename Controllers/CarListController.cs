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
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Car.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Car.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Car.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "ClientList");
        }
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Car.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Car obj)
        {
            _db.Car.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "ClientList");
        }
    }
}
