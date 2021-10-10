using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearchWebApp.Models
{
    public class ProfileModel
    {
        public List<User> userdetails { get; set; }
        public List<SavedJob> savedjob { get; set; }
        //public int loggedUser { get; set; }

        public ProfileModel(int loggedUser)
        {
            JobSearchDBEntities1 db = new JobSearchDBEntities1();

            userdetails = db.Users.Where(i => i.UserId == loggedUser).ToList();
            savedjob = db.SavedJobs.Where(i => i.UserId == loggedUser).ToList();
        }
    }
}