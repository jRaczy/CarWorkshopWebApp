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
    public class RepairController : Controller
    {
        private readonly ApplicationDbContext _db;
        public RepairController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(Car car)
        {
            IEnumerable<Appointment> objList = _db.Appointment.Where(x => x.Car == car);
            return View(objList);
        }
        public IActionResult Create(Car car)
        {
            AppointmentVM appointmentVM = new AppointmentVM()
            {
                Appointment = new Appointment(),
                SelectListItems = _db.Car.Select(i => new SelectListItem
                {
                    Value = i.Id.ToString()
                })

            };
            appointmentVM.Appointment.Car = car;
            appointmentVM.Appointment.CarId= car.Id;
            return View(appointmentVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AppointmentVM obj)

        {
            var car = _db.Car.Include(x => x.Appointment).FirstOrDefault(x => x.Id == obj.Appointment.CarId);
            obj.Appointment.Status = "Open";
            obj.Appointment.Cost = 0;
            _db.Appointment.Add(obj.Appointment);
            _db.SaveChanges();
            return RedirectToAction("Index",new { id = obj.Appointment.CarId });
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Appointment.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Appointment.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Appointment.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "ClientList");
        }
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Appointment.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Appointment obj)
        {
            _db.Appointment.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "ClientList");
        }
        public IActionResult OpenRepair()
        {
            IEnumerable<Appointment> objList = _db.Appointment.Where(x => x.Status == "Open");
            return View(objList);
        }
    }
}
