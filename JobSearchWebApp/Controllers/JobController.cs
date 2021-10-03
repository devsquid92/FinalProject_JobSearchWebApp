using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearchWebApp.Models;

namespace JobSearchWebApp.Controllers
{
    public class JobController : Controller
    {
        // GET: Job
        public ActionResult Index()
        {
            using(JobSearchDBEntities1 db = new JobSearchDBEntities1())
            {
                return View(db.Jobs.ToList());
            }    

        }


        public ActionResult jobSearch(string jobtitle)
        {

            JobSearchDBEntities1 db = new JobSearchDBEntities1();
            var sea = db.Jobs
                .WhereIf(jobtitle != null, j => j.Title.StartsWith(jobtitle))
                .ToList();

            return View(sea);
        }


        public ActionResult AddJob()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddJob(Job job)
        {
            if (ModelState.IsValid)
            {
                using (JobSearchDBEntities1 db = new JobSearchDBEntities1())
                {
                    db.Jobs.Add(job);
                    db.SaveChanges();
                }

                ModelState.Clear();
                ViewBag.Message = job.JobsId + " " + job.Title + " successfuly added.";
            }
            return View();
        }




    }
}