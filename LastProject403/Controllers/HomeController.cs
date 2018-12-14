using LastProject403.DAL;
using LastProject403.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}