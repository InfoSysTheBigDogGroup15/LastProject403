using LastProject403.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LastProject403.Models;
using System.Web.Security;

namespace LastProject403.Controllers
{
    public class RealHomeController : Controller
    {
        // GET: RealHome
        private StrawContext db = new StrawContext();
        public ActionResult Index()
        {
            return View();
        }
        //get
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            string email = form["Username"];
            string password = form["Password"];
            //linear search
            //reroute find role send to dashboard
            List<Users> AllUsers = db.User.ToList();
            bool YN = false;
            foreach (Users User1 in AllUsers)
            {
                if (User1.userEmail == email && User1.password == password)
                {
                    FormsAuthentication.SetAuthCookie(email, rememberMe);
                    return RedirectToAction("Index", "RealHome");
                }


            }
            return View();
        }
        public ActionResult Logout()
        {

            if (User.Identity.IsAuthenticated == true)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "RealHome");
            }
            else
            {
                return RedirectToAction("Login", "RealHome");
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,userEmail,password,firstname,lastname")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }
        public ActionResult OrderStraws()
        {
            ViewBag.strawID = new SelectList(db.Straw, "strawID", "strawMaterial");
            ViewBag.userID = new SelectList(db.User, "userID", "userEmail");
            return View();
        }
    }
}