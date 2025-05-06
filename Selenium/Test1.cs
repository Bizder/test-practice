using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium
{
    [TestClass]
    public class GoogleTests
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
        public void OpenGoogleTest()
        {
            driver.Navigate().GoToUrl("https://google.com/ncr");

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath("//*[text()='Accept all']"))).Click();
            }
            catch (NoSuchElementException)
            {
                // Popup not shown – continue silently
            }

            Assert.AreEqual("Google", driver.Title);
        }

        [TestMethod]
        public void GoogleSearchTest()
        {
            driver.Navigate().GoToUrl("https://www.google.com/ncr");

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath("//*[text()='Accept all']"))).Click();
            }
            catch (NoSuchElementException)
            {
                // Popup not shown – continue silently
            }

            var box = driver.FindElement(By.Name("q"));
            box.SendKeys("Selenium WebDriver");
        }

    }

}
