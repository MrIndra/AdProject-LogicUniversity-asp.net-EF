using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AD4.Controllers
{
    public class StoreController : Controller
    {
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult RaiseStockAdjustment()
        {
            return View();
        }

        public ActionResult PendingAdjustment()
        {
            return View();
        }

        public ActionResult Adjustment()
        {
            return View();
        }
    }
}