using AD4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using AD4.Service;

namespace AD4.Controllers
{
    public class DepartmentController : Controller
    {
        [AuthorizeRoles(RolesType.Admin)]
        [Authorize]
        public ActionResult Delegate()
        {
            using (DbContextSln users = new DbContextSln())
            {
                List<Users> user = users.dbUsers.ToList();
                ViewData["uname"] = User.Identity.Name;
                Debug.WriteLine(User.Identity.ToString());
                Debug.WriteLine(User.Identity.Name);
                Debug.WriteLine(User.Identity.IsAuthenticated);
                ViewData["users"] = user;
            }
            return View();
        }

        [Authorize]
        public ActionResult History()
        {
            ViewData["uname"] = User.Identity.Name;
            return View();
        }

        [Authorize]
        public ActionResult OrderItem()
        {
            using (DbContextSln dbsol = new DbContextSln())
            {
                List<Items> list = dbsol.orderItems.ToList();
                //var groups = dbsol.orderItems.GroupBy(x => x.Category, i => i, 
                //    (key,v)=> new Items { Category = key, Name = v}).ToList();
                ViewData["uname"] = User.Identity.Name;
                return View(list);
            }
           
        }

        [Authorize]
        public ActionResult OrderView()
        {
            ViewData["uname"] = User.Identity.Name;
            return View();
        }

        [Authorize]
        public ActionResult PickUpForm()
        {
            ViewData["uname"] = User.Identity.Name;
            return View();
        }

        [Authorize]
        public ActionResult RetrievalForm()
        {
            ViewData["uname"] = User.Identity.Name;
            return View();
        }

    }
}