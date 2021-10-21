using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
//using Xunit;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobSearchWebApp.AutomatedUITests
{
    [TestClass]
    public class AutomatedUITests
    {
        private readonly IWebDriver _driver;

        public AutomatedUITests()
        {
            _driver = new ChromeDriver();
        }

        private static void DelayForDemo()
        {

            // A function that delays a procedure before continuing its next task.
            Thread.Sleep(1000);
        }

        public void NavigateToProfile()
        {
            // A function that will easily navigate to user profile if needed in the procedure.
            _driver.Navigate().GoToUrl("http://localhost:44395/Account/LoggedIn");
        }

        [TestMethod]
        public void launchBrowser()
        {
            // Checking the title of the current page given by the url.
            _driver.Navigate().GoToUrl("http://localhost:44395/");

            Assert.AreEqual("Home Page - Job Search Portal", _driver.Title);
        }

        [TestMethod]
        public void ShouldUserLogin()
        {
            // Logging in by entering automated keys provided.
            _driver.Navigate().GoToUrl("http://localhost:44395/Account/Login");

            //Enter email
            IWebElement email = _driver.FindElement(By.Name("Email"));
            email.SendKeys("jm.ramirez@it.weltec.ac.nz");
            DelayForDemo();

            //Enter password
            IWebElement password = _driver.FindElement(By.Name("Password"));
            password.SendKeys("password123");
            DelayForDemo();

            _driver.FindElement(By.ClassName("btn-default")).Click();

        }

        [TestMethod]
        public void ShouldUserFindJobs()
        {
            // To see if it navigates correctly to ensure connection.
            _driver.Navigate().GoToUrl("http://localhost:44395/Job");

        }


        [TestMethod]
        public void ShouldUserSearchJob()
        {
            // Attempts to search using the search function by entering automated keys.
            var searchTitle = "Programmer";

            ShouldUserFindJobs();

            //Enter job search
            IWebElement jotitle = _driver.FindElement(By.Name("jobtitle"));
            jotitle.SendKeys(searchTitle);
            DelayForDemo();

            //Submit search
            _driver.FindElement(By.ClassName("btn-default")).Click();
            DelayForDemo();

        }

        [TestMethod]
        public void ShouldUserSaveJob()
        {
            //Testing to see if the searched job can be save after logging in.
            //User logging in
            ShouldUserLogin();
            DelayForDemo();

            //User search job
            ShouldUserSearchJob();
            DelayForDemo();

            //Click searched save job
            _driver.FindElement(By.Name("save")).Click();
            DelayForDemo();

            //Check profile
            NavigateToProfile();

        }


        [TestMethod]
        public void ShouldUserDeleteSavedJob()
        {
            //Testing the delete function from user profile after logging in.
            ShouldUserLogin();
            _driver.FindElement(By.Name("delete")).Click();

        }

        [TestMethod]
        public void ShouldUserRegister()
        {
            //Testing the registration function by providing automated keys.
            _driver.Navigate().GoToUrl("http://localhost:44395/Account/Register");

            //Enter first name
            IWebElement fname = _driver.FindElement(By.Name("FName"));
            fname.SendKeys("Tester");
            DelayForDemo();

            //Enter last name
            IWebElement lname = _driver.FindElement(By.Name("LName"));
            lname.SendKeys("Testing");
            DelayForDemo();

            //Enter email
            IWebElement email = _driver.FindElement(By.Name("Email"));
            email.SendKeys("testing@it.weltec.ac.nz");
            DelayForDemo();

            //Enter phone
            IWebElement phone = _driver.FindElement(By.Name("Phone"));
            phone.SendKeys("2102531972");
            DelayForDemo();

            //Enter date of birth
            _driver.FindElement(By.Name("DOB")).Click();
            selectDate();
            DelayForDemo();

            //Enter gender
            IWebElement gender = _driver.FindElement(By.Name("Gender"));
            gender.SendKeys("Male");
            DelayForDemo();

            //Enter password
            IWebElement password = _driver.FindElement(By.Name("Password"));
            password.SendKeys("password123");
            DelayForDemo();

            //Enter confirm password
            IWebElement confirmPass = _driver.FindElement(By.Name("ConfirmPassword"));
            confirmPass.SendKeys("password123");
            DelayForDemo();

            _driver.FindElement(By.ClassName("btn-default")).Click();


        }


        public void selectDate()
        {
            // a simple function that allows to select date from datepicker feature.
            _driver.FindElement(By.ClassName("ui-state-default")).Click();
        }

        [TestMethod]
        public void ShouldUserAddJob()
        {
            //Testing to see if adding a job will work with provided automated keys.
            _driver.Navigate().GoToUrl("http://localhost:44395/Job/AddJob");

            IWebElement title = _driver.FindElement(By.Name("Title"));
            title.SendKeys("Testing");
            DelayForDemo();

            IWebElement comname = _driver.FindElement(By.Name("ComName"));
            comname.SendKeys("MTester");
            DelayForDemo();

            IWebElement email = _driver.FindElement(By.Name("Email"));
            email.SendKeys("tester@co.nz");
            DelayForDemo();

            IWebElement phone = _driver.FindElement(By.Name("Phone"));
            phone.SendKeys("2102531972");
            DelayForDemo();

            IWebElement address = _driver.FindElement(By.Name("Address"));
            address.SendKeys("4333 Tester Street Petone");
            DelayForDemo();

            _driver.FindElement(By.Name("Date")).Click();
            selectDate();
            DelayForDemo();

            IWebElement jobdesc = _driver.FindElement(By.Name("JobDesc"));
            jobdesc.SendKeys("More testing..........");
            DelayForDemo();

            _driver.FindElement(By.ClassName("btn-default")).Click();

        }







    }
}
