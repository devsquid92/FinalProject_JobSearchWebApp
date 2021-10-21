using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearchWebApp.Models;
using Quartz;

namespace JobSearchWebApp.Controllers
{
    public class JobUnitTestController : Controller
    {

        public List<Job> GetJobList()
        {
            var today = SystemTime.Now().Date;

            var future = SystemTime.UtcNow().Date;

            return new List<Job>
            { new Job
                {
                    Title = "Tester",
                    ComName = "Unit Testing",
                    Email = "unit.testing@weltec.nz",
                    Phone = 0212534343,
                    Date = today,
                    Address = "321 Unit Testing Street",
                    JobDesc = "Testing the waters",
                },
                 new Job
                {
                    Title = "Tester1",
                    ComName = "Unit Testing1",
                    Email = "unit.testing1@weltec.nz",
                    Phone = 1212534343,
                    Date = future,
                    Address = "123 Unit Testing Street",
                    JobDesc = "Testing the ocean",
                },


            };

        }

        public ActionResult Index()
        {
            var jobs = from s in GetJobList() select s;

            return View(jobs);
        }


        [HttpPost]
        public ActionResult AddJob()
        {
            if (ModelState.IsValid)
            {
                var today = SystemTime.Now().Date;


                Job job = new Job();

                job.Title = "Unit";
                job.ComName = "Unit Testing";
                job.Email = "unit.testing@weltec.ac.nz";
                job.Date = today;
                job.Address = "432 Unit Testing";
                job.Phone = 432432433;
                job.JobDesc = "Add job testing";


                ModelState.Clear();
                ViewBag.Message = job.Title + " " + job.ComName + " successfully added job.";
            }
            return View();
        }
    }
}