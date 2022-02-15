using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWorkshop.Data;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Models;


namespace CarWorkshop.Controllers
{
    public class AddClientController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AddClientController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client obj)
        {
            _db.Client.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
