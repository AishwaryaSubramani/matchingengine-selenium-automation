using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using NUnit.Framework;
using MatchingEngineAutomation.Utilities;


namespace MatchingEngineAutomation.PageObjects
{

    public class RepertoireManagementPage
    {
        internal readonly IWebDriver driver;
        internal readonly WebDriverWait wait;

        public RepertoireManagementPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        internal string Url => "https://www.matchingengine.com/";

        // Elements (accessed only through waits in actions)
        internal By ModulesMenu => By.XPath("//a[contains(text(), 'Modules')]");
        internal By RepertoireModule => By.LinkText("Repertoire Management Module");
        internal By AdditionalFeatures => By.XPath("//h2[contains(text(), 'Additional Features')]");
        internal By ProductsSupported => By.XPath("//span[contains(text(), 'Products Supported')]/parent::a");
        internal By ProductHeading => By.XPath("//h3[contains(text(), 'There are several types of Product Supported')]");
        internal By ProductItems => By.XPath("//h3[contains(.,'There are several types of Product Supported')]/following::ul[1]/li");


        public class Actions
        {
            private readonly RepertoireManagementPage page;

            public Actions(RepertoireManagementPage page)
            {
                this.page = page;
            }

            public void GoToRepertoireManagementPage()
            {
                page.driver.Navigate().GoToUrl(page.Url);
                page.wait.Until(driver => driver.Url.Contains("matchingengine.com"));
            }

            public void NavigateToRepertoireModule()
            {
                var modules = page.wait.Until(driver => driver.FindElement(page.ModulesMenu));
                var action = new OpenQA.Selenium.Interactions.Actions(page.driver);
                action.MoveToElement(modules).Perform();

                var repModule = page.wait.Until(driver => driver.FindElement(page.RepertoireModule));
                repModule.Click();
            }

            public void ScrollToAdditionalFeatures()
            {
                var element = page.wait.Until(driver => driver.FindElement(page.AdditionalFeatures));
                ((IJavaScriptExecutor)page.driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }

            public void ClickProductsSupported()
            {
                var productsTab = page.wait.Until(driver => driver.FindElement(page.ProductsSupported));
                productsTab.Click();
            }

            
            public void AssertProductHeadingVisible()
{
    var productsTab = page.wait.Until(d => d.FindElement(page.ProductsSupported));
    productsTab.Click();

    var heading = page.wait.Until(d =>
    {
        var el = d.FindElement(page.ProductHeading);
        return el.Displayed ? el : null;
    });

    ((IJavaScriptExecutor)page.driver).ExecuteScript("arguments[0].scrollIntoView(true);", heading);
    heading.ShouldBeVisible("Heading for supported products not visible.");
}


            public void AssertProductVisible(string productName)
            {
                 var items = page.wait.Until(d => d.FindElements(page.ProductItems));
                 var texts = items.Select(x => x.Text.Trim()).ToList();

        Assert.That(
        texts.Any(t => t.Equals(productName, StringComparison.OrdinalIgnoreCase)),
        Is.True,
        $"Product '{productName}' not found. Found: {string.Join(", ", texts)}"
    );

            }
        }
    }
}
