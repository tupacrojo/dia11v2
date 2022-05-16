using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dia11v2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            ViewBag.Message = "tu privacidad";

            return View();
        }

        public ActionResult Unidades()
        {
            ViewBag.Message = "que tenemos.";

            return View();
        }
    }
}