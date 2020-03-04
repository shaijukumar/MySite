using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySite.Models;

namespace MySite.Controllers
{
    public class ContentDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContentDatas
        public ActionResult Index()
        {
            var contentDatas = db.ContentDatas.Include(c => c.Category);
            return View(contentDatas.ToList());
        }

        // GET: ContentDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentData contentData = db.ContentDatas.Find(id);
            if (contentData == null)
            {
                return HttpNotFound();
            }
            return View(contentData);
        }

        // GET: ContentDatas/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: ContentDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContentDataId,CategoryId,Title,URLString,Content")] ContentData contentData)
        {
            if (ModelState.IsValid)
            {
                db.ContentDatas.Add(contentData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", contentData.CategoryId);
            return View(contentData);
        }

        // GET: ContentDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentData contentData = db.ContentDatas.Find(id);
            if (contentData == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", contentData.CategoryId);
            return View(contentData);
        }

        // POST: ContentDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContentDataId,CategoryId,Title,URLString,Content")] ContentData contentData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contentData).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", contentData.CategoryId);
            return View(contentData);
        }

        // GET: ContentDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentData contentData = db.ContentDatas.Find(id);
            if (contentData == null)
            {
                return HttpNotFound();
            }
            return View(contentData);
        }

        // POST: ContentDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContentData contentData = db.ContentDatas.Find(id);
            db.ContentDatas.Remove(contentData);
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
