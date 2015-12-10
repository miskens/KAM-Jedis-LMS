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
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Documents
        public ActionResult Index() //int id
        {
            //string owningEntity = Functions.ParseDocumentOwnerEntity(id);

            //var documents = context.Documents.Where(d => d.GroupId == id);

            return View();
        }

        // GET: Documents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = context.Documents.Find(id);
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
        //public ActionResult Create([Bind(Include = "Name, Description, GroupId, CourseId, ActivityId, UserId, UploadTime")] Document document, HttpPostedFileBase uploadFile)
        public ActionResult Create([Bind(Include = "Name, Description, GroupId, CourseId, ActivityId, UserId")] Document document, HttpPostedFileBase uploadFile)
        {
            string sender = string.Empty;
            if (Request.RequestContext.RouteData.Values["sender"] != null)
            {
                sender = Request.RequestContext.RouteData.Values["sender"].ToString();
            }

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
                        OriginalFileName = uploadFile.FileName,
                        Description = document.Description,
                        UserId = document.UserId,
                        Uri = fileName,
                        UploadTime = DateTime.Now,
                    };
                    
                    // Set only the "important" value. ActivityId if the doc is connected to an activity,
                    // else check if it is connected to a course and lastly check if it is connected to a group.
                    // userId (owner) is always set, regardless of it has a connection or not.
                    if (document.ActivityId.ToString() != "0")
                    {
                        uploadedDocument.ActivityId = document.ActivityId;
                    }
                    else if (document.CourseId.ToString() != "0")
                    {
                        uploadedDocument.CourseId = document.CourseId;
                    }
                    else if (document.GroupId.ToString() != "0")
                    { 
                        uploadedDocument.GroupId = document.GroupId; 
                    }

                    uploadFile.SaveAs(path);
                    
                    context.Documents.Add(uploadedDocument);  
                }
                
                context.SaveChanges();

                
                if (document.ActivityId != 0)
                {
                    return RedirectToAction("Details", "Activities", new {id=document.ActivityId, sender=sender, gId = document.GroupId, cId = document.CourseId});
                }
                if (document.CourseId != 0)
                {
                    return RedirectToAction("Details", "Courses", new { id = document.CourseId, sender = sender, gId = document.GroupId });
                }
                if (document.GroupId != 0)
                {
                    return RedirectToAction("Details", "Group", new { id = document.GroupId, sender=sender });
                }


                // all that is left is documents created at a user...
                return RedirectToAction("Details", "Users", new { id = document.UserId, sender = sender });
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
            Document document = context.Documents.Find(id);
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
                context.Entry(document).State = EntityState.Modified;
                context.SaveChanges();
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
            Document document = context.Documents.Find(id);
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
            Document document = context.Documents.Find(id);
            context.Documents.Remove(document);
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
