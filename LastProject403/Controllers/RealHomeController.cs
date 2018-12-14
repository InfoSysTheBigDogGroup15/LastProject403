using LastProject403.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LastProject403.Models;
using System.Web.Security;
using System.Net;
using System.Data.Entity;

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
                bool rememberMe = false;
                db.User.Add(users);
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(users.userEmail, rememberMe);
                return RedirectToAction("Index");
            }

            return View(users);
        }

        public ActionResult Catalog()
        {
            return View(db.Straw.ToList());
        }
        [Authorize]
        public ActionResult OrderStraws()
        {
            ViewBag.strawID = new SelectList(db.Straw, "strawID", "strawMaterial");
            ViewBag.userID = new SelectList(db.User, "userID", "userEmail");
            return View();
        }

        // POST: Orders1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
        [Authorize]
        public ActionResult ManageOrder()
        {
            return View(db.Order.ToList());
        }

        // GET: Orders1/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Orders orders = db.Order.Find(id);
        //    if (orders == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(orders);
        //}

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
        public ActionResult DisplayQuestions()
        {   
            return View(db.Comments.ToList());
        }
        public ActionResult AnswerQ(int? id)
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
        [HttpPost]
        public ActionResult AnswerQ([Bind(Include = "commentID,userName,question,answers")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DisplayQuestions");
            }
            return View(comments);
        }
        public ActionResult CreateQuestion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateQuestion([Bind(Include = "commentID,userName,question,answers")] Comments comments)
        {
            comments.userName = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.Comments.Add(comments);
                db.SaveChanges();
                return RedirectToAction("DisplayQuestions");
            }

            return View(comments);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }

        // GET: Orders1/Delete/5
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
        // POST: Orders1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders orders = db.Order.Find(id);
            db.Order.Remove(orders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Orders1/Edit/5
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
            ViewBag.userID = new SelectList(db.User, "userID", "userEmail", orders.userID);
            return View(orders);
        }

        // POST: Orders1/Edit/5
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
            ViewBag.userID = new SelectList(db.User, "userID", "userEmail", orders.userID);
            return View(orders);
        }

    }


}