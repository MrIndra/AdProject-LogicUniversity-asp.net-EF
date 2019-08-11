using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AD4.Models;

namespace AD4.Controllers
{
    
    public class HomeController : Controller
    {
        [HttpPost]
        public JsonResult About()
        {
                Debug.WriteLine("invoked");
                return Json(new { accesstoken = "abc" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Contact()
        {
            return Json(new { accesstoken = "abc" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult About(int? a)
        {
            return Json(new { accesstoken = "abc" }, JsonRequestBehavior.AllowGet);
        }
    }
}