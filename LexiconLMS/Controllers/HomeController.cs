using System;
using LexiconLMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LexiconLMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var context = new ApplicationDbContext();
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var currentUserId = User.Identity.GetUserId();
                var user = userManager.Users.FirstOrDefault(u => u.Id == currentUserId);
                ViewBag.FullName = user.FullName;
                
                if (user.GroupId.HasValue)
                {
                    var group = context.Groups.Find(user.GroupId); 
                    ViewBag.Group = group.Name;
                }

                if (User.IsInRole("lärare")) 
                {
                    var groups = context.Groups.ToList();
                    ViewBag.Groups = groups;

                    var courses = context.Courses.ToList();
                    ViewBag.Courses = courses;
                }
            }

            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }

    public static class MailHandler
    {
        public static SmtpClient ConfigureSmtpClient()
        {
            SmtpClient client = new SmtpClient();

            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("Lexicontestmail@gmail.com", "T3st1ngMail");
            client.Host = "smtp.gmail.com";

            return client;
        }
    }
}