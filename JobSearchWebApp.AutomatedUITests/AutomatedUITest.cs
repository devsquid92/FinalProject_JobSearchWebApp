using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
//using Xunit;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

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

        [TestMethod]
        public void launchBrowser()
        {
            _driver.Navigate().GoToUrl("http://localhost:44395/");

            Assert.AreEqual("Index - JobSearchWebApp", _driver.Title);
        }

        [TestMethod]
        public void ShouldUserLogin()
        {
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

        private static void DelayForDemo()
        {
            Thread.Sleep(1000);
        }

    }
}
