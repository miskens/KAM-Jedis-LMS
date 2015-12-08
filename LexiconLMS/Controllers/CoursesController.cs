using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.Mvc;
using LexiconLMS.Models;

namespace LexiconLMS.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Courses
        public ActionResult Index()
        {
            return View(context.Courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = context.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        [Authorize(Roles="lärare")]
        public ActionResult Create()
        {
            //int groupId = 0;
            //if (Request.RequestContext.RouteData.Values["gId"] != null)
            //{
            //    groupId = Int32.Parse(Request.RequestContext.RouteData.Values["gId"].ToString());
            //}
            //var group = context.Groups.FirstOrDefault(g => g.Id == groupId);

            //IDictionary<string, int> groupWithIndex = new Dictionary<string, int>();
            //groupWithIndex.Add(group.Name, group.Id);

            //ViewBag.Group = groupWithIndex;
            return View();
        }

        // POST: Courses/Create
        [Authorize(Roles = "lärare")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,StartDate,EndDate,GroupId")] Course model)
        {
            if (ModelState.IsValid)
            {
                int groupId = 0;
                if (Request.RequestContext.RouteData.Values["gId"] != null)
                {
                    groupId = Int32.Parse(Request.RequestContext.RouteData.Values["gId"].ToString());
                }

                var group = context.Groups.FirstOrDefault(g => g.Id == groupId);
                DateTime start = group.StartDate;
                DateTime end = group.EndDate;
                string dateTimeFailureMessage = Functions.CheckDatesForCourse(model, start, end, DateTime.Today);

                if (dateTimeFailureMessage != string.Empty)
                {
                    ModelState.AddModelError("", dateTimeFailureMessage);
                    return View(model);
                }

                model.GroupId = groupId;

                context.Courses.Add(model);
                context.SaveChanges();
                return RedirectToAction("Details", "Group", new { id = model.GroupId, sender = "g"});
            }

            return View(model);
        }

        // GET: Courses/Edit/5
        [Authorize(Roles = "lärare")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = context.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        [Authorize(Roles = "lärare")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,StartDate,EndDate,GroupId")] Course model)
        {
            if (ModelState.IsValid)
            {
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Details", "Group", new { id = model.GroupId, sender = "g" });
            }
            return View();
        }

        // GET: Courses/Delete/5
        [Authorize(Roles = "lärare")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = context.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [Authorize(Roles = "lärare")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = context.Courses.Find(id);
            context.Courses.Remove(course);
            context.SaveChanges();
            return RedirectToAction("Details", "Group", new { id = course.GroupId, sender = "g" });
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
