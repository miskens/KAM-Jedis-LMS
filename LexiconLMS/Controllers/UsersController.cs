using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LexiconLMS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LexiconLMS.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Users
        [Authorize(Roles = "lärare")]
        public ActionResult Index()
        {
            var users = context.Users.ToList();

            foreach (var user in users)
            {
                if (user.Roles.Count > 0)
                { 
                    var roleId = user.Roles.FirstOrDefault().RoleId;
                    user.Role = context.Roles.Where(r => r.Id == roleId).FirstOrDefault().Name;
                }
            }

            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = context.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }

            if (applicationUser.GroupId != null)
            { 
                var applicationUserGroup = (context.Groups.Where(g => g.Id == applicationUser.GroupId).FirstOrDefault()).Name;
                ViewBag.Group = applicationUserGroup;
            }

            return View(applicationUser);
        }

        //// GET: Users/Create
        //[Authorize(Roles = "lärare")]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Users/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "lärare")]
        //public ActionResult Create([Bind(Include = "Id,FullName,Active,GroupId,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Users.Add(applicationUser);
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(applicationUser);
        //}

        // GET: Users/Edit/5
        [Authorize(Roles = "lärare")]
        public ActionResult Edit(string id)
        {
            var groupsList = context.Groups.ToList();
            IDictionary<string, int> groups = new Dictionary<string, int>();
            foreach (var group in groupsList)
            {
                groups.Add(group.Name, group.Id);
            }
            ViewBag.Groups = groups;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = context.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,FullName,Active,GroupId,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        [Authorize(Roles = "lärare")]
        public ActionResult Edit(ApplicationUser appUser)
        {
            if (ModelState.IsValid)
            {
                int groupId = 0;
                if (Request.RequestContext.RouteData.Values["gId"] != null)
                {
                    groupId = Int32.Parse(Request.RequestContext.RouteData.Values["gId"].ToString());
                }

                var user = context.Users.Find(appUser.Id);

                user.FullName = appUser.FullName;
                user.GroupId = appUser.GroupId;
                user.Active = appUser.Active;
                user.UserName = appUser.UserName;
                user.Email = appUser.Email;

                context.Users.AddOrUpdate(u => u.Id,
                    user);
                context.SaveChanges();
                return RedirectToAction("Details", "Group", new { id = groupId, sender = "g"}
            );
            }
            return RedirectToAction("Index", "Users");
        }

        // GET: Users/Delete/5
        [Authorize(Roles = "lärare")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = context.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "lärare")]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = context.Users.Find(id);
            context.Users.Remove(applicationUser);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
