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
using System.IO;

namespace LexiconLMS.Controllers
{
    public class HomeController : Controller
    {
        string userId = "";

        ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Index()
        {
            watch();
            if (User.Identity.IsAuthenticated)
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var currentUserId = User.Identity.GetUserId();
                var user = userManager.Users.FirstOrDefault(u => u.Id == currentUserId);
                ViewBag.FullName = user.FullName;

                userId = user.Id;
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

        FileSystemWatcher watcher = new FileSystemWatcher();
        public void watch()
        {
            string strWorkingDirectory = Directory.GetCurrentDirectory();

            string fullSubFolderPath = strWorkingDirectory + "\\Content\\StudentAssignments";

            if(!Directory.Exists(fullSubFolderPath))
            { 
                Directory.CreateDirectory(fullSubFolderPath);
            }

            watcher.Path = fullSubFolderPath;
            watcher.Path = @"C:\Program Files (x86)\IIS Express\Content\StudentAssignments\";
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Created += new FileSystemEventHandler(watch_OnCreated);
            watcher.EnableRaisingEvents = true;
            watcher.NotifyFilter =
                NotifyFilters.Attributes |
                NotifyFilters.CreationTime |
                NotifyFilters.FileName |
                NotifyFilters.LastWrite |
                NotifyFilters.Size;
        }
        private void watch_OnCreated(object source, FileSystemEventArgs e)
        {
            SmtpClient client = Functions.ConfigureSmtpClient();

            MailMessage message = new MailMessage();
            MailAddress receiver = new MailAddress("miskens@hotmail.com");
            MailAddress sender = new MailAddress("LexiconLMS@lexicon.se");

            
            ApplicationUser user = context.Users.Find(userId);

            var group = context.Groups.Find(user.GroupId);

            message.Sender = sender;
            message.To.Add(receiver);
            message.IsBodyHtml = false;
            message.Body = "Nya inlämningsuppgifter har lagts till av " + user.FullName + "." + Environment.NewLine + 
                                "Grupp: " + group.Name;
            message.From = sender;
            message.Subject = "Inkomna inlämningsuppgifter";

            client.Send(message);
        }
    }
}