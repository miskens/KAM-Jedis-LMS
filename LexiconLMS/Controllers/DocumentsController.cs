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
    [Authorize]
    public class DocumentsController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Documents
        public ActionResult Index()
        {
            IEnumerable<Document> documents = new List<Document>();
            string groupId = "0";
            if (Request.RequestContext.RouteData.Values["gId"] != null)
            {
                groupId = Request.RequestContext.RouteData.Values["gId"].ToString();
                documents = context.Documents.Where(d => d.GroupId.ToString() == groupId);
            }
            string courseId = "0";
            if (Request.RequestContext.RouteData.Values["cId"] != null)
            {
                courseId = Request.RequestContext.RouteData.Values["cId"].ToString();
                documents = context.Documents.Where(d => d.CourseId.ToString() == courseId);
            }
            string activityId = "0";
            if (Request.RequestContext.RouteData.Values["aId"] != null)
            {
                activityId = Request.RequestContext.RouteData.Values["aId"].ToString();
                documents = context.Documents.Where(d => d.ActivityId.ToString() == activityId);
            }

            ViewData["groupId"] = groupId;
            ViewData["courseId"] = courseId;
            ViewData["activityId"] = activityId;
            if (groupId != "0")
            { 
                return View("ListGroupDocuments", documents);
            }
            if (courseId != "0")
            {
                return RedirectToAction("ListCourseDocuments", documents);
            }
            if (activityId != "0")
            {
                return RedirectToAction("ListActivityDocuments", documents );
            }
            return RedirectToAction("ListAllDocuments", context.Documents);
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
        [Authorize(Roles = "lärare")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="lärare")]
        public ActionResult Create([Bind(Include = "Name, Description, GroupId, CourseId, ActivityId, UserId, UploadTime")] Document document, HttpPostedFileBase uploadFile)
        {
            string sender = string.Empty;
            if (Request.RequestContext.RouteData.Values["sender"] != null)
            {
                sender = Request.RequestContext.RouteData.Values["sender"].ToString();
            }

            string groupId = "0";
            if (Request.RequestContext.RouteData.Values["gId"] != null)
            {
                groupId = Request.RequestContext.RouteData.Values["gId"].ToString();
            }

            string courseId = "0";
            if (Request.RequestContext.RouteData.Values["cId"] != null)
            {
                courseId = Request.RequestContext.RouteData.Values["cId"].ToString();
            }

            string activityId = "0";
            if (Request.RequestContext.RouteData.Values["aId"] != null)
            {
                activityId = Request.RequestContext.RouteData.Values["aId"].ToString();
            }

             if (uploadFile.ContentLength == 0)
            {
                ModelState.AddModelError("", "Dokumentet är tomt, försök med ett annat.");
                return View();
            }

            if (ModelState.IsValid)
            {
                if (uploadFile.ContentLength > 0)
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
                    context.SaveChanges();
                }


                if (sender == "g")
                { 
                    return RedirectToAction("Index", new { gId = groupId });
                }
                if (sender == "c")
                {
                    return RedirectToAction("Index", new { cId = courseId });
                }
                if (sender == "a")
                {
                    return RedirectToAction("Index", new { aId = activityId });
                }
            }

            return View(document);
        }

        // GET: Documents/Edit/5
        [Authorize(Roles = "lärare")]
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
        [Authorize(Roles = "lärare")]
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
        [Authorize(Roles = "lärare")]
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
        [Authorize(Roles = "lärare")]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = context.Documents.Find(id);
            context.Documents.Remove(document);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult download()
        {
            return View(context.Documents.ToList());
        }


        public FileResult GetFileFromDisk(string fileUri, string originalFileName)
        {
            var fileOnDisk = System.IO.Path.Combine(Server.MapPath("/Content/uploads/"), fileUri);
            string mimeType = MimeMapping.GetMimeMapping(originalFileName);

            return File(fileOnDisk, mimeType, originalFileName);

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
