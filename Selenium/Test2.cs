using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
    [TestClass]
    public class LifecycleTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void OpenGoogleTest()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            Assert.AreEqual("Google", driver.Title);
        }
    }
}
