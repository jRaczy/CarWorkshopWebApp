using CarWorkshop.Data;
using CarWorkshop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CarWorkshop.Controllers
{
    public class EmailController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmailController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SendEmail(EmailSend obj)
        {
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new System.Net.NetworkCredential("janraczy3@gmail.com", "Franek1702"); // Enter seders User name and password       
        smtp.EnableSsl = true;

        MailMessage mail = new MailMessage();
        mail.To.Add(obj.EmailTo);
        mail.From = new MailAddress("janraczy3@gmail.com");
        mail.Subject = obj.Subject;
        mail.Body = obj.Message;
        mail.IsBodyHtml = false;
        smtp.Send(mail);

            return RedirectToAction("Index", "ClientList");
        }
    }
}
