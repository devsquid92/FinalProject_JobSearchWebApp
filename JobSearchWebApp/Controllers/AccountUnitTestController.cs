using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearchWebApp.Models;
using Quartz;

namespace JobSearchWebApp.Controllers
{
    public class AccountUnitTestController : Controller
    {
        // GET: AccountUnitTest
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register()
        {
            if (ModelState.IsValid)
            {
                var today = SystemTime.Now().Date;


                User user = new User();

                user.FName = "Unit";
                user.LName = "Testing";
                user.Phone = 123456789;
                user.Email = "unit.testing@weltec.com";
                user.Gender = "Male";
                user.DOB = today;
                user.Password = "password123";
                user.ConfirmPassword = "password123";

                //using (JobSearchDBEntities1 db = new JobSearchDBEntities1())
                //{
                //    db.Users.Add(user);
                //    db.SaveChanges();
                //}

                ModelState.Clear();
                ViewBag.Message = user.FName + " " + user.LName + " successfully registered.";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            User user = new User();

            user.Email = "unit.testing@weltec.com";
            user.Password = "wrong123";

            User u = new User();

            u.Email = "unit.testing@weltec.com";
            u.Password = "password123";

            try
                {
                    
                    if (u.Email == user.Email && u.Password == user.Password)
                    {
                        Session["UserID"] = user.UserId.ToString();
                        Session["Email"] = user.Email.ToString();
                        Session["FName"] = user.FName.ToString();

                        return RedirectToAction("LoggedIn");
                    }
                }
                catch
                {
                    ModelState.AddModelError("invalid", "Invalid Email or Password.");
                }

            
            return View();
        }


        public List<SavedJob> GetSavedJobs()
        {
            return new List<SavedJob>
            {
                new SavedJob
                {
                    SJobId = 99,
                    JobsId = 1,
                    UserId = 2,
                },
                new SavedJob
                {
                    SJobId = 98,
                    JobsId = 2,
                    UserId = 2,
                },
                new SavedJob
                {
                    SJobId = 97,
                    JobsId = 3,
                    UserId = 2,
                },
            };
        }

        public ActionResult del()
        {
            var sjobList = GetSavedJobs();

            var sjobs = sjobList.Where(s => s.SJobId == 98).ToList();

            foreach(var sjob in sjobs)
            {
                sjobList.Remove(sjob);
            }
                
            return View(sjobList);
        }

        public List<User> GetUserInfo()
        {
            var today = SystemTime.Now().Date;
            return new List<User>
            {
                new User
                {
                UserId = 1,
                FName = "Unit",
                LName = "Testing",
                Phone = 123456789,
                Email = "unit.testing@weltec.com",
                Gender = "Male",
                DOB = today,
                Password = "password123",
                ConfirmPassword = "password123",
                },
            };
        }

        public ActionResult Edit()
        {
            var userList = GetUserInfo();

            userList.Find(u => u.UserId == 1).FName = "NewUnit";


            return View(userList);
        }

    }
}