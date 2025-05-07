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
        public TestContext TestContext { get; set; }

        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            var options = new ChromeOptions();

            if (Environment.GetEnvironmentVariable("CI") == "true")
            {
                options.AddArgument("--headless");
                options.AddArgument("--disable-gpu");
            }
            driver = new ChromeDriver(options);
        }

        [TestCleanup]
        public void TearDown()
        {
            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
            {
                try
                {
                    var dir = Path.Combine(Directory.GetCurrentDirectory(), "screenshots");
                    Directory.CreateDirectory(dir);

                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    var path = Path.Combine(dir, $"{TestContext.TestName}.png");
                    screenshot.SaveAsFile(path);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Screenshot capture failed: {ex.Message}");
                }
            }

            driver?.Quit();
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
            catch (Exception ex)
            {
                Console.WriteLine($"Screenshot capture failed: {ex.Message}");
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
            catch (Exception ex)
            {
                Console.WriteLine($"Screenshot capture failed: {ex.Message}");
            }

            var box = driver.FindElement(By.Name("q"));
            box.SendKeys("Selenium Driver");
        }

    }

}
