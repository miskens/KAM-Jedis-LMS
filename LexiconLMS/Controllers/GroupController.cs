using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LexiconLMS.Models;

namespace LexiconLMS.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult Index()
        {
            return View();
        }

        // GET: Group/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Group/Create
        [HttpGet]
        public ActionResult CreateGroup()
        {
            return View();
        }

        // POST: Group/Create
        [HttpPost]
        public ActionResult CreateGroup(Group model)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            try
            {
                if (ModelState.IsValid)
                {
                    var group = new Group { Name = model.Name, Description = model.Description, StartDate = model.StartDate, EndDate = model.EndDate };
                    context.Groups.Add(group);
                    context.SaveChanges();

                    //Ändra till /Groups-vyn sen
                        return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Group/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Group/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Group/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Group/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
