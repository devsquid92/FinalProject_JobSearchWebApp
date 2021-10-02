using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearchWebApp.Models;

namespace JobSearchWebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using (JobSearchDBEntities db = new JobSearchDBEntities())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }

                ModelState.Clear();
                ViewBag.Message = user.FName + " " + user.LName + " successfuly registered.";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (JobSearchDBEntities db = new JobSearchDBEntities())
            {
                var usr = db.Users.Single(u => u.Email == user.Email && u.Password == user.Password);

                if (usr != null)
                {
                    Session["UserID"] = usr.UserId.ToString();
                    Session["Email"] = usr.Email.ToString();
                    Session["FName"] = usr.FName.ToString();

                    return RedirectToAction("LoggedIn");
                }

                else
                {
                    ModelState.AddModelError("", "Email or Password is wrong.");

                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }

            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}