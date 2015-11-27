using System;
using LexiconLMS.Models;
using System.Collections.Generic;
using System.Linq;
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
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                
                ApplicationUser user = manager.FindById(User.Identity.GetUserId());
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
}