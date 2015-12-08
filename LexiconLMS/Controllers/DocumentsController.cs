using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LexiconLMS.Models;
using System.IO;

namespace LexiconLMS.Controllers
{

    public class DocumentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Documents
        public ActionResult Index()
        {
            return View(db.Documents.ToList());
        }

        // GET: Documents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: Documents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Description, GroupId, CourseId, ActivityId, UserId, UploadTime")] Document document, HttpPostedFileBase uploadFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadFile != null && uploadFile.ContentLength > 0)
                {
                    //var fileName = Path.GetFileName(file.FileName);
                    
                    
                    string fileExtension = uploadFile.FileName.Split('.').Last();
                    var fileName = Path.GetRandomFileName() + '.' + fileExtension;
                    var path = Path.Combine(Server.MapPath("~/Content/uploads"), fileName);

                    var uploadedDocument = new Document
                    {
                        Name = document.Name,
                        Description = document.Description,
                        UserId = document.UserId,
                        Uri = fileName,
                        UploadTime = document.UploadTime,
                        GroupId = document.GroupId,
                        CourseId = document.CourseId,
                        ActivityId = document.ActivityId
                    };
                    
                    // Set only the "important" value. ActivityId if the doc is connected to an activity,
                    // else check if it is connected to a course and lastly check if it is connected to a group.
                    // userId (owner) is always set, regardless of it has a connection or not.
                    if (document.ActivityId != 0)
                    {
                        uploadedDocument.ActivityId = document.ActivityId;
                    }
                    else if (document.CourseId != 0)
                    {
                        uploadedDocument.CourseId = document.CourseId;
                    }
                    else if (document.GroupId != 0)
                    { 
                        uploadedDocument.GroupId = document.GroupId; 
                    }

                    uploadFile.SaveAs(path);
                    
                    db.Documents.Add(uploadedDocument);  
                }
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(document);
        }

        // GET: Documents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Uri,Name,Description,UploadTime,GroupId,CourseId,UserId,ActivityId")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(document);
        }

        // GET: Documents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
