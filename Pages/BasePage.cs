using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace NextBasketChallenge.Pages
{
    public class BasePage
    {
        private IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public WebDriverWait Wait()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public Actions ActionItem()
        {
            return new Actions(driver);
        }

        public IWebElement FindElement(By locator)
        {
            return driver.FindElement(locator);
        }

        public List<IWebElement> FindElements(By locator)
        {
            return new List<IWebElement>(driver.FindElements(locator));
        }

        public void ClickElement(By locator)
        {
            FindElement(locator).Click();
        }

        public void ClearElement(By locator)
        {
            FindElement(locator).Clear();
        }

        public bool ElementIsDisplaying(By locator)
        {
            return FindElement(locator).Displayed;
        }

        public void EnterText(By locator, string textToEnter)
        {
            FindElement(locator).SendKeys(textToEnter);
        }

        public void WaitTillElementIsDisplayed(By locator)
        {
            Wait().Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitTillElementIsClickable(By locator)
        {
            Wait().Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public void WaitTillElementToBeDisplayedAndClickable(By locator)
        {
            WaitTillElementIsDisplayed(locator);
            WaitTillElementIsClickable(locator);
        }

        public void WaitTillURLContains(string textWithInURL)
        {
            Wait().Until(ExpectedConditions.UrlContains(textWithInURL));
        }

        public void ScrollToWebElement(By locator)
        {
            IWebElement element = driver.FindElement(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript(
                "arguments[0].scrollIntoView(true);",
                element
            );
        }

        public void ScrollTillTop()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, -200)");
        }

        public string GetCurrentURL()
        {
            return driver.Url;
        }

        public void MoveToElementAndPerform(By locator){
            ActionItem().MoveToElement(FindElement(locator)).Build().Perform();
        }
    }
}
