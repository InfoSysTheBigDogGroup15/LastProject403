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
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
    }
}