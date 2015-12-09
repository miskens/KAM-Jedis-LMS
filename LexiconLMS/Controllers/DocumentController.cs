using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LexiconLMS.Models;

namespace LexiconLMS.Controllers
{
    public class DocumentController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Document
        public ActionResult Index()
        {
            //string ownerEntityName = Functions.ParseDocumentOwnerEntity();
            //var referrer = Request.UrlReferrer.ToString();
            //if (referrer.Contains("Group"))
            //{

            //}
            //context.Documents.Where(d => d.Id ==)

            return View();
        }

        // GET: Document/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Document/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Document/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Document/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Document/Edit/5
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

        // GET: Document/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Document/Delete/5
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
