using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JobSearchWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using JobSearchWebApp;
using System.Web.Mvc;

namespace TestingEnviroment
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AccountRegisterUT()
        {
            //Arrange: Initialise objects and sets the value of sample data used in the method being tested
            AccountUnitTestController con = new AccountUnitTestController();

            //Act: Invoke the method being tested
            ViewResult result = con.Register() as ViewResult;

            //Assert: Verify the tested method behaves as expected
            Assert.AreEqual("Unit Testing successfully registered.", result.ViewBag.Message);
        }

        [TestMethod]
        public void AccountUserLoginUT()
        {
            //Arrange: Initialise objects and sets the value of sample data used in the method being tested
            AccountUnitTestController con = new AccountUnitTestController();

            //Act: Invoke the method being tested
            ViewResult result = con.Login() as ViewResult;

            //Assert: Verify the tested method behaves as expected
            Assert.IsTrue(result.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void JobIndexUT()
        {
            //Arrange: Initialise objects and sets the value of sample data used in the method being tested
            JobUnitTestController con = new JobUnitTestController();

            //Act: Invoke the method being tested
            ViewResult result = con.Index() as ViewResult;

            //Assert: Verify the tested method behaves as expected
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void JobAddJobUT()
        {
            //Arrange: Initialise objects and sets the value of sample data used in the method being tested
            JobUnitTestController con = new JobUnitTestController();

            //Act: Invoke the method being tested
            ViewResult result = con.AddJob() as ViewResult;

            //Assert: Verify the tested method behaves as expected
            Assert.AreEqual("Unit Unit Testing successfully added job.", result.ViewBag.Message);
        }

        [TestMethod]
        public void SavedJobDeleteUT()
        {
            //Arrange: Initialise objects and sets the value of sample data used in the method being tested
            AccountUnitTestController con = new AccountUnitTestController();

            //Act: Invoke the method being tested
            ViewResult result = con.del() as ViewResult;

            //Assert: Verify the tested method behaves as expected
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditUserUT()
        {
            //Arrange: Initialise objects and sets the value of sample data used in the method being tested
            AccountUnitTestController con = new AccountUnitTestController();

            //Act: Invoke the method being tested
            ViewResult result = con.Edit() as ViewResult;

            //Assert: Verify the tested method behaves as expected
            Assert.IsNotNull(result);
        }
    }
}

