using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace HighconWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }


        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string name, string u_email, string subject, string message)
        {
            try
            {
                string from = System.Configuration.ConfigurationManager.AppSettings.Get("UserID");
                string password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");
                using (MailMessage email = new MailMessage(from, "info@highcontech.com"))
                {
                    email.Subject = "Contact - " + subject;
                    email.Body = name + " sent a message from within the ganaf website. \nMessage Content: \n" + message + "\n\nEmail Address: " + u_email;
                    email.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential networkCredential = new NetworkCredential(from, password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.Send(email);
                    ViewBag.Status = "SUCCESS";
                    ViewBag.StatusMessage = "Message successfully sent";

                }
            }
            catch (Exception)
            {
                ViewBag.Status = "ERROR";
                ViewBag.StatusMessage = "Something went wrong. Please retry.";
            }
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }
    }
}
