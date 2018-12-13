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
    public class InventoriesController : Controller
    {
        private StrawContext db = new StrawContext();

        // GET: Inventories
        public ActionResult Index()
        {
            var inventory = db.Inventory.Include(i => i.Straws);
            return View(inventory.ToList());
        }

        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventories inventories = db.Inventory.Find(id);
            if (inventories == null)
            {
                return HttpNotFound();
            }
            return View(inventories);
        }

        // GET: Inventories/Create
        public ActionResult Create()
        {
            ViewBag.strawID = new SelectList(db.Straw, "strawID", "strawMaterial");
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "inventoryID,strawID,quantity")] Inventories inventories)
        {
            if (ModelState.IsValid)
            {
                db.Inventory.Add(inventories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.strawID = new SelectList(db.Straw, "strawID", "strawMaterial", inventories.strawID);
            return View(inventories);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventories inventories = db.Inventory.Find(id);
            if (inventories == null)
            {
                return HttpNotFound();
            }
            ViewBag.strawID = new SelectList(db.Straw, "strawID", "strawMaterial", inventories.strawID);
            return View(inventories);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "inventoryID,strawID,quantity")] Inventories inventories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.strawID = new SelectList(db.Straw, "strawID", "strawMaterial", inventories.strawID);
            return View(inventories);
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventories inventories = db.Inventory.Find(id);
            if (inventories == null)
            {
                return HttpNotFound();
            }
            return View(inventories);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventories inventories = db.Inventory.Find(id);
            db.Inventory.Remove(inventories);
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
