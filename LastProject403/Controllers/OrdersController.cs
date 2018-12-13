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
    public class OrdersController : Controller
    {
        private StrawContext db = new StrawContext();

        // GET: Orders
        public ActionResult Index()
        {
            var order = db.Order.Include(o => o.Straws).Include(o => o.Users);
            return View(order.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Order.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.strawID = new SelectList(db.Straw, "strawID", "strawMaterial");
            ViewBag.userID = new SelectList(db.StrawUser, "userID", "userEmail");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderID,strawID,userID,quantityOrdered")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Order.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.strawID = new SelectList(db.Straw, "strawID", "strawMaterial", orders.strawID);
            ViewBag.userID = new SelectList(db.StrawUser, "userID", "userEmail", orders.userID);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Order.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.strawID = new SelectList(db.Straw, "strawID", "strawMaterial", orders.strawID);
            ViewBag.userID = new SelectList(db.StrawUser, "userID", "userEmail", orders.userID);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderID,strawID,userID,quantityOrdered")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.strawID = new SelectList(db.Straw, "strawID", "strawMaterial", orders.strawID);
            ViewBag.userID = new SelectList(db.StrawUser, "userID", "userEmail", orders.userID);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Order.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders orders = db.Order.Find(id);
            db.Order.Remove(orders);
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
