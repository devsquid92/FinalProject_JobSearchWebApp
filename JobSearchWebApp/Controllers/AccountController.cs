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
                using (JobSearchDBEntities1 db = new JobSearchDBEntities1())
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
            using (JobSearchDBEntities1 db = new JobSearchDBEntities1())
            {
                try
                {
                    var usr = db.Users.Single(u => u.Email == user.Email && u.Password == user.Password);

                    if (usr != null)
                    {
                        Session["UserID"] = usr.UserId.ToString();
                        Session["Email"] = usr.Email.ToString();
                        Session["FName"] = usr.FName.ToString();

                        return RedirectToAction("LoggedIn");
                    }
                }
                catch
                {
                    ModelState.AddModelError("invalid", "Invalid Email or Password.");
                }

            }
            return View();
        }

        //public ActionResult LoggedIn()
        //{
        //    if (Session["UserId"] != null)
        //    {

        //        JobSearchDBEntities1 db = new JobSearchDBEntities1();

        //            var userId = Convert.ToInt32(Session["UserId"]);
        //            var dets = db.SavedJobs.Where(i => i.UserId == userId);

        //            return View(dets.ToList());

        //    }

        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }
        //}

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                var userId = Convert.ToInt32(Session["UserId"]);

                ProfileModel profileModel = new ProfileModel(userId);

                return View(profileModel);

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

        public ActionResult del(int sjobId)
        {
            if (ModelState.IsValid)
            {
                JobSearchDBEntities1 db = new JobSearchDBEntities1();
                SavedJob savejob = new SavedJob();

                var saveJobId = db.SavedJobs.Find(sjobId);
                db.SavedJobs.Remove(saveJobId);
                db.SaveChanges();

                ViewBag.Message = "Saved Job Id: " + savejob.JobsId + " is successfuly deleted from your profile.";
                return View();

            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            if (ModelState.IsValid)
            {
                JobSearchDBEntities1 db = new JobSearchDBEntities1();
                User user = db.Users.Single(i => i.UserId == id);

                return View(user);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                var userId = Convert.ToInt32(Session["UserId"]);


                JobSearchDBEntities1 db = new JobSearchDBEntities1();
                //var edit = db.Users.Where(i => i.UserId == userId).FirstOrDefault();
                var edit = db.Users.Single(i => i.UserId == userId);
                edit.FName = user.FName;
                edit.LName = user.LName;
                edit.Email = user.Email;
                edit.Phone = user.Phone;
                edit.DOB = user.DOB;
                //edit.Password = user.Password;
                edit.ConfirmPassword = user.ConfirmPassword;
                db.SaveChanges();

                Session["FName"] = edit.FName.ToString();


                return RedirectToAction("LoggedIn");
            }
            catch(System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }


        }


    }
}