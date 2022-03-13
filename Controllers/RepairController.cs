using CarWorkshop.Data;
using CarWorkshop.Models;
using CarWorkshop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace CarWorkshop.Controllers
{
    public class RepairController : Controller
    {
        private readonly ApplicationDbContext _db;
        private string addres= "jas.20@o2.pl";

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
            if(obj.Appointment.Cost > 0)
            {
                _db.Appointment.Add(obj.Appointment);
                _db.SaveChanges();
            }
            else {
                obj.Appointment.Cost = 0;
                _db.Appointment.Add(obj.Appointment);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", new { id = obj.Appointment.CarId });
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
        public ActionResult CloseAppointment(int? id)
        {
            var obj = _db.Appointment.Find(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult CloseAppointment(Appointment obj)
        {
            var appointment = _db.Appointment.Find(obj.Id);
            appointment.Status = "Closed";
            _db.SaveChanges();

            var car = _db.Car.Find(appointment.CarId);
            var clientId = car.ClientId;
            var client = _db.Client.Find(clientId);
            string subject = "Repair of the " + car.Mark + " " + car.Model;
            if (ModelState.IsValid)
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("janraczy3@gmail.com", "Franek1702"); // Enter seders User name and password       
                smtp.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.To.Add(client.Email);
                mail.From = new MailAddress(addres);
                mail.Subject = "Repair of the " + car.Mark + car.Model + DateTime.Today;
                string Body = "Diagnosis of the car: " + appointment.Diagnosis + "And used parts: " + appointment.Parts + "Cost overall" + appointment.Cost;
                mail.Body = Body;
                mail.IsBodyHtml = false;
                smtp.Send(mail);
                return RedirectToAction("Index", "ClientList");
            }
            else
            {
                return View();
            }
        }
    }
}
