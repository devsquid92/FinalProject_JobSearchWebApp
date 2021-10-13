using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JobSearchWebApp.AutomatedUITests
{
    public class AutomatedUITests : IDisposable
    {
        private readonly IWebDriver _driver;
        public AutomatedUITests()
        {
            _driver = new ChromeDriver();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void Login_WhenExecuted_LoginView()
        {
            _driver.Navigate()
                .GoToUrl("");
            Assert.Equal("Index", _driver.Title);
            Assert.Contains("Login", _driver.PageSource);
        }
    }
}
