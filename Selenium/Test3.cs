using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumDemo.Tests
{
    [TestClass]
    public class WaitTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void DuckDuckGoSearch_WithWait()
        {
            driver.Navigate().GoToUrl("https://duckduckgo.com");

            var searchBox = driver.FindElement(By.Id("search_form_input_homepage"));
            searchBox.SendKeys("selenium");
            searchBox.SendKeys(Keys.Enter);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleContains("selenium"));

            Assert.IsTrue(driver.Title.ToLower().Contains("selenium"));
        }
    }
}