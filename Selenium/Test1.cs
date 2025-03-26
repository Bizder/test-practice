using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium
{
    [TestClass]
    public class GoogleTests
    {
        [TestMethod]
        public void OpenGoogleTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://google.com/ncr");
            Assert.AreEqual("Google", driver.Title);

            System.Threading.Thread.Sleep(3000);

            try
            {
                var acceptButton = driver.FindElement(By.XPath("//div[contains(text(),'Accept all')]"));
                acceptButton.Click();
            }
            catch (NoSuchElementException)
            {
                // Popup not shown – continue silently
            }

            System.Threading.Thread.Sleep(3000);

            driver.Quit();
        }

        [TestMethod]
        public void GoogleSearchTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            var box = driver.FindElement(By.Name("q"));
            box.SendKeys("Selenium WebDriver");
            box.SendKeys(Keys.Enter);
            Assert.IsTrue(driver.Title.Contains("Selenium WebDriver"));
        }

    }

}
