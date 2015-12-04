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
                ViewBag.UserId = user.Id;

                if (User.IsInRole("elev"))
                {
                    Group group = context.Groups.Find(user.GroupId);
                    ViewBag.Group = group.Name;
                    ViewBag.Groupid = group.Id;
                    ViewBag.GroupDescription = group.Description;
                    ViewBag.GroupStart = group.StartDate;
                    ViewBag.GroupEnd = group.EndDate;

                    IEnumerable<Course> courses = (from c in context.Courses
                                                  where c.GroupId == user.GroupId
                                                  orderby c.StartDate ascending
                                                  select c).ToList();

                    ViewBag.ActiveCourses = courses.Where(c => c.StartDate <= DateTime.Today && c.EndDate >= DateTime.Today);
                    ViewBag.FutureCourses = courses.Where(c => c.StartDate > DateTime.Today);
                    ViewBag.FinishedCourses = courses.Where(c => c.EndDate < DateTime.Today);

                    ViewBag.HasActiveCourses = courses.Where(c => c.StartDate <= DateTime.Today && c.EndDate >= DateTime.Today).Count() > 0;
                    ViewBag.HasFutureCourses = courses.Where(c => c.StartDate > DateTime.Today).Count() > 0;
                    ViewBag.HasFinishedCourses = courses.Where(c => c.EndDate < DateTime.Today).Count() > 0;

                    
                    IEnumerable<Activity> activities = (from c in context.Courses
                                                       from a in c.Activities
                                                       where (c.GroupId == user.GroupId)
                                                       orderby a.StartDate ascending
                                                       select a).ToList();

                    ViewBag.ActiveActivities = activities.Where(a => a.StartDate <= DateTime.Today && a.EndDate >= DateTime.Today);
                    ViewBag.FutureActivities = activities.Where(a => a.StartDate > DateTime.Today);
                    ViewBag.FinishedActivities = activities.Where(a => a.EndDate < DateTime.Today);

                    ViewBag.HasActiveActivities = activities.Where(a => a.StartDate <= DateTime.Today && a.EndDate >= DateTime.Today).Count() > 0;
                    ViewBag.HasFutureActivities = activities.Where(a => a.StartDate > DateTime.Today).Count() > 0;
                    ViewBag.HasFinishedActivities = activities.Where(a => a.EndDate < DateTime.Today).Count() > 0;

                }

                if (User.IsInRole("lärare"))
                {
                    IEnumerable<Group> groups = from g in context.Groups
                                                orderby g.StartDate ascending
                                                select g;

                    ViewBag.ActiveGroups = groups.Where(g => g.StartDate <= DateTime.Today && g.EndDate >= DateTime.Today);
                    ViewBag.FutureGroups = groups.Where(g => g.StartDate > DateTime.Today);
                    ViewBag.FinishedGroups = groups.Where(g => g.EndDate < DateTime.Today);

                    ViewBag.HasActiveGroups = groups.Where(g => g.StartDate <= DateTime.Today && 
                                                                g.EndDate >= DateTime.Today).Count() > 0;
                    ViewBag.HasFutureGroups = groups.Where(g => g.StartDate > DateTime.Today).Count() > 0;
                    ViewBag.HasFinishedGroups = groups.Where(g => g.EndDate < DateTime.Today).Count() > 0;

                    
                    
                    var courses = context.Courses.ToList();
                    ViewBag.Courses = courses;
                }
            }

            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Om.....";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakter";

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