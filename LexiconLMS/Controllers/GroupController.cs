using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using LexiconLMS.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace LexiconLMS.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Group
        public ActionResult Index()
        {
            if (User.IsInRole("lärare"))
            {
                var groups = context.Groups.ToList();
                return TGroups(groups);
            }
            else
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var currentUserId = User.Identity.GetUserId();
                var user = userManager.Users.FirstOrDefault(u => u.Id == currentUserId);

                return StudentGroup(user.GroupId.Value, user.GroupId.ToString());
            }
        }

        // GET: Show Groups for teachers
        [Authorize(Roles = "lärare")]
        public ActionResult TGroups(List<Group> groups)
        {
            return View("TGroups", groups);   
        }

        // GET: Show Group students Group
        [Authorize(Roles = "elev,lärare")]
        public ActionResult StudentGroup(int id, string userGroupId)
        {
            var group = context.Groups.FirstOrDefault(g => g.Id.ToString() == userGroupId);
            return View("StudentGroup", group);
        }


        // GET: Group/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var group = context.Groups
                       .Where(g => g.Id == id)
                       .FirstOrDefault();

            return View(group);
        }

        // GET: Group/Create
        [HttpGet]
        [Authorize(Roles = "lärare")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        [HttpPost]
        [Authorize(Roles = "lärare")]
        public ActionResult Create(Group model)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            try
            {
                if (ModelState.IsValid)
                {
                    var group = new Group { Name = model.Name, Description = model.Description, StartDate = model.StartDate, EndDate = model.EndDate };
                    context.Groups.Add(group);
                    context.SaveChanges();

                    return RedirectToAction("Index", "Group");
                }
                return RedirectToAction("Index", "Group");
            }
            catch
            {
                return View();
            }
        }

        // GET: Group/Edit/5
        [HttpGet]
        [Authorize(Roles = "lärare")]
        public ActionResult Edit(int id)
        {
            var group = context.Groups
          .Where(g => g.Id == id)
          .FirstOrDefault();

            return View(group);
        }

        // POST: Group/Edit/5
        [HttpPost]
        [Authorize(Roles = "lärare")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
            foreach (string _formData in collection)
            {
                ViewData[_formData] = collection[_formData];
            }
                var group = context.Groups
                .Where(g => g.Id == id)
                .FirstOrDefault();

                group.Name = Convert.ToString(collection["Name"]);
                group.Description = Convert.ToString(collection["Description"]);
                group.StartDate = Convert.ToDateTime(collection["StartDate"]);
                group.EndDate = Convert.ToDateTime(collection["EndDate"]);

                context.Groups.AddOrUpdate(g => g.Id,
                     group);

                context.SaveChanges();

                return RedirectToAction("Index", "Group");
            }
            catch
            {
                return View();
            }
        }

        // GET: Group/Delete/5
        [HttpGet]
        [Authorize(Roles = "lärare")]
        public ActionResult Delete(int id)
        {
            var group = context.Groups
           .Where(g => g.Id == id)
           .FirstOrDefault();

            return View(group);
        }

        // POST: Group/Delete/5
        [HttpPost]
        [Authorize(Roles = "lärare")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var group = context.Groups
                .Where(g => g.Id == id)
                .FirstOrDefault();

                context.Groups.Remove(group);
                context.SaveChanges();

                return RedirectToAction("Index", "Group");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GroupmemberDetails(string id)
        {
            ApplicationUser applicationUser = context.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }
    }
}
