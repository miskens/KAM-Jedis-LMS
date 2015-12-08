using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LexiconLMS.Models;
using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Controllers
{
    [Authorize]
    public class ActivitiesController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Activities
        [Authorize(Roles = "lärare")]
        public ActionResult Index()
        {
            return View(context.Activities.ToList());
        }

        // GET: Activities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = context.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }

            ViewBag.CourseName = context.Courses.Find(activity.CourseId).Name;
            return View(activity);
        }

        [Authorize(Roles = "lärare")]
        // GET: Activities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "lärare")]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Type,StartDate,EndDate,CourseId")] Activity model)
        {
            if (ModelState.IsValid)
            {
                var course = context.Courses.FirstOrDefault(c => c.Id == model.CourseId);
                DateTime start = course.StartDate;
                DateTime end = course.EndDate;

                string dateTimeFailureMessage = Functions.CheckDatesForActivity(model, start, end, DateTime.Today);

                if (dateTimeFailureMessage != string.Empty)
                {
                    ModelState.AddModelError("", dateTimeFailureMessage);
                    return View(model);
                }

                context.Activities.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        
        // GET: Activities/Edit/5
        [Authorize(Roles = "lärare")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = context.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        
        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "lärare")]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Type,StartDate,EndDate,CourseId")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                context.Entry(activity).State = EntityState.Modified;
                context.SaveChanges();

                var course = context.Courses.FirstOrDefault(c => c.Id == activity.CourseId);
                var group = context.Courses.FirstOrDefault(g => g.Id == course.GroupId);
                var groupId = group.Id;
                return RedirectToAction("Details", "Courses", new { id = activity.CourseId, sender = "g", gId = groupId});
            }
            return View(activity);
        }

        
        // GET: Activities/Delete/5
        [Authorize(Roles = "lärare")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = context.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "lärare")]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = context.Activities.Find(id);
            context.Activities.Remove(activity);
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
