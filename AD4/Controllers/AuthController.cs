using AD4.Models;
using AD4.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AD4.Controllers
{
    public class AuthController : Controller
    {
        //Login
        public ActionResult Login()
        {
            return View();
        }

        //Login-Post
        //On[Authorize]..it goes to web config and comes here..and redirects to the returnUrl...
        //here it stores the user details..
        [HttpPost]
        public ActionResult Login(Users users, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            using (DbContextSln sln = new DbContextSln())
            {
                Users authUser = sln.dbUsers.FirstOrDefault(x => x.username == users.username);
                if (authUser == null)
                {
                    ViewData["warning1"] = "Wrong Username, Please try again";
                    return View(users);//provide this so taht user dont have to type again and agian.
                }
                if (authUser.password.ToLower() != CalculateMD5Hash(users.password).ToLower())
                {
                    ViewData["warning2"] = "Wrong Password, Please try again";
                    return View(users);
                }
                FormsAuthentication.SetAuthCookie(authUser.username, false);//persistent cookie for 2nd value...remember me check box
                FormsAuthentication.SetAuthCookie(Convert.ToString(authUser.user_id), false);
                var authTicket = new FormsAuthenticationTicket(1, authUser.username, DateTime.Now, DateTime.Now.AddMinutes(20), false, authUser.Roles);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("OrderItem", "Department");
            }
        }

        //Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("OrderItem", "Department");
        }


        public string CalculateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
       
        //Access Denied Page..
        [Authorize]
        public ActionResult AccessDenied()
        {
            if (User.IsInRole("Admin"))
            {
                ViewData["uname"] = User.Identity.Name;
                return RedirectToAction("Delegate", "Department");
            }
            else
            ViewData["uname"] = User.Identity.Name;
            return View();
        }
    }
}