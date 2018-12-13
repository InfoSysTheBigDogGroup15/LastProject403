using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LastProject403.DAL;
using LastProject403.Models;

namespace LastProject403.Controllers
{
    public class Straws1Controller : Controller
    {
        private StrawContext db = new StrawContext();

        // GET: Straws1
        public ActionResult Index()
        {
            return View(db.Straw.ToList());
        }

        // GET: Straws1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Straws straws = db.Straw.Find(id);
            if (straws == null)
            {
                return HttpNotFound();
            }
            return View(straws);
        }

        // GET: Straws1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Straws1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "strawID,strawMaterial,strawHeight,strawColor")] Straws straws)
        {
            if (ModelState.IsValid)
            {
                db.Straw.Add(straws);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(straws);
        }

        // GET: Straws1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Straws straws = db.Straw.Find(id);
            if (straws == null)
            {
                return HttpNotFound();
            }
            return View(straws);
        }

        // POST: Straws1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "strawID,strawMaterial,strawHeight,strawColor")] Straws straws)
        {
            if (ModelState.IsValid)
            {
                db.Entry(straws).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(straws);
        }

        // GET: Straws1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Straws straws = db.Straw.Find(id);
            if (straws == null)
            {
                return HttpNotFound();
            }
            return View(straws);
        }

        // POST: Straws1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Straws straws = db.Straw.Find(id);
            db.Straw.Remove(straws);
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
