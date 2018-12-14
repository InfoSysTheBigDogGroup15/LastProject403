using LastProject403.DAL;
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
    }
}