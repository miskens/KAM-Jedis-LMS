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
                
                if (User.IsInRole("elev"))
                {
                    Group group = context.Groups.Find(user.GroupId); 
                    ViewBag.Group = group.Name;

                     List<Course> activeCourses = (from c in context.Courses
                                                  where (c.GroupId == user.GroupId &&
                                                  c.StartDate <= DateTime.Today &&
                                                  c.EndDate >= DateTime.Today)
                                                  orderby c.StartDate ascending
                                                  select c).ToList();
                    ViewBag.ActiveCourses = activeCourses;

                    List<Course> finishedCourses = (from c in context.Courses
                                                  where (c.GroupId == user.GroupId &&
                                                  c.EndDate < DateTime.Today)
                                                  orderby c.StartDate ascending
                                                  select c).ToList();
                    ViewBag.FinishedCourses = finishedCourses;

                    List<Course> futureCourses = (from c in context.Courses
                                                    where (c.GroupId == user.GroupId &&
                                                    c.StartDate > DateTime.Today)
                                                    orderby c.StartDate ascending
                                                    select c).ToList();
                    ViewBag.FutureCourses = futureCourses;

                    ViewBag.HasActiveCourses = (activeCourses.Count() > 0);
                    ViewBag.HasFinishedCourses = (finishedCourses.Count() > 0);
                    ViewBag.HasFutureCourses = (futureCourses.Count() > 0);
                }

                if (User.IsInRole("lärare")) 
                {
                    IEnumerable<Group> activeGroups = from g in context.Groups
                                 where (g.StartDate <= DateTime.Today && 
                                        g.EndDate >= DateTime.Today)
                                 orderby g.StartDate descending
                                 select g;
                    ViewBag.ActiveGroups = activeGroups;
                    ViewBag.HasActiveGroups = (activeGroups.Count() > 0);

                    IEnumerable<Group> finishedGroups = from g in context.Groups
                                                        where g.EndDate < DateTime.Today
                                                        orderby g.EndDate descending
                                                        select g;
                    ViewBag.FinishedGroups = finishedGroups;
                    ViewBag.HasFinishedGroups = (finishedGroups.Count() > 0);

                    IEnumerable<Group> futureGroups = from g in context.Groups
                                                      where g.StartDate > DateTime.Today
                                                      orderby g.StartDate ascending
                                                      select g;
                    ViewBag.FutureGroups = futureGroups;
                    ViewBag.HasFutureGroups = (futureGroups.Count() > 0);

                    // make active/FUTURE AND FINISHED GROUPINGS TUESDAY
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