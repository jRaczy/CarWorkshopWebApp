using CarWorkshop.Data;
using CarWorkshop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Controllers
{
    public class ClientListController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ClientListController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Client> objList = _db.Users;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
