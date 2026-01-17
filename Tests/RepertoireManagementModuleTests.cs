using NUnit.Framework;
using OpenQA.Selenium;
using MatchingEngineAutomation.Drivers;
using MatchingEngineAutomation.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace MatchingEngineAutomation.Tests
{
    public class RepertoireManagementTest
    {
        private IWebDriver driver;
        private RepertoireManagementPage.Actions pageActions;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = WebDriverFactory.CreateDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var page = new RepertoireManagementPage(driver, wait);
            pageActions = new RepertoireManagementPage.Actions(page);
        }

        [Test]
        public void ValidateSupportedProducts()
        {
            pageActions.GoToRepertoireManagementPage();

             try
            {
                var allowAll = driver.FindElement(By.XPath("//button[contains(.,'Allow all')]"));
                allowAll.Click();
            }
            catch (NoSuchElementException)
            {
                // banner not shown
            }
            catch (ElementClickInterceptedException)
            {
                
                var allowAll = driver.FindElement(By.XPath("//button[contains(.,'Allow all')]"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", allowAll);
            }

            pageActions.NavigateToRepertoireModule();
            pageActions.ScrollToAdditionalFeatures();
            pageActions.ClickProductsSupported();
            pageActions.AssertProductHeadingVisible();

            string[] expectedProducts = { "Cue Sheet / AV Work", "Recording", "Bundle", "Advertisement" };
            foreach (var product in expectedProducts)
            {
                pageActions.AssertProductVisible(product);
            }
        }

        [TearDown]
        public void Teardown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null!;
            }
        }
    }
}
