using LastProject403.DAL;
using LastProject403.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LastProject403.Controllers
{
    public class HomeController : Controller
    {
        private StrawContext db = new StrawContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Catalog()
        {
            return View(db.Straw.ToList());
        }

        public ActionResult OrderStraws()
        {
            ViewBag.strawID = new SelectList(db.Straw, "strawID", "strawMaterial");
            ViewBag.userID = new SelectList(db.User, "userID", "userEmail");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderStraws([Bind(Include = "orderID,strawID,userID,quantityOrdered")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Order.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.strawID = new SelectList(db.Straw, "strawID", "strawMaterial", orders.strawID);
            ViewBag.userID = new SelectList(db.User, "userID", "userEmail", orders.userID);
            return View(orders);
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        public ActionResult ManageOrder()
        {
            return View(db.Order.ToList());
        }

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
            return View(orders);
        }

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

        public ActionResult FAQ()
        {
            return View(db.Comments.ToList());
        }

        public ActionResult CreateComment()
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment([Bind(Include = "commentID,userName,comments")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comments);
                db.SaveChanges();
                return RedirectToAction("FAQ");
            }

            return View(comments);
        }

        public ActionResult AddAnswer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = db.Comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            return View(comments);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAnswer([Bind(Include = "commentID,answers")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("FAQ");
            }
            return View(comments);
        }
    }
}