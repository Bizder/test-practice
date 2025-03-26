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
        [TestMethod]
        public void OpenGoogleTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://google.com/ncr");
            Assert.AreEqual("Google", driver.Title);

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Iframe-re várás és váltás
                // wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(
                //     By.CssSelector("iframe[src^='https://consent.google.com']")));

                // Gombra várás és kattintás
                wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath("//*[text()='Accept all']"))).Click();
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
