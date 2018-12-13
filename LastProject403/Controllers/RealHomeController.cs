using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LastProject403.Controllers
{
    public class RealHomeController : Controller
    {
        // GET: RealHome
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
            string username = form["Username"];
            string password = form["Password"];
            //linear search
            //reroute find role send to dashboard
            //List<UserAuth> auths = db.UserAuths.ToList();
            //bool YN = false;
            //foreach (UserAuth auth in auths)
            //{
            //    if (auth.username == username && auth.password == password)
            //    {
            //        FormsAuthentication.SetAuthCookie(auth.authorizationID.ToString(), rememberMe);
            //        return RedirectToAction("Index", "Home");
            //    }


            //}
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
    }
}