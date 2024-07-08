using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace NextBasketChallenge.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public Actions actionItem()
        {
            return new Actions(driver);
        }

        public WebDriverWait wait()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        By workProduct = By.XPath("//img[@alt='Work']");
        By acceptAllButton = By.XPath("//*[@id='root']/div[1]/div/div[2]/button[1]");

        By productBuyButton = By.XPath("//button[@aria-label='Add to basket Work']");

        By cartButton = By.XPath(
            "//button[@aria-label='Open basket menu']//div[@class='gIvgG']//*[name()='svg']"
        );

        By goToPaymentButton = By.XPath("//p[normalize-space()='Go to payment']");

        public void waitTillElementIsDisplayed(By locatorName)
        {
            wait().Until(ExpectedConditions.ElementIsVisible(locatorName));
        }

        public void waitTillElementIsClickable(By locatorName)
        {
            wait().Until(ExpectedConditions.ElementToBeClickable(locatorName));
        }

        public void elementToBeDisplayedOrClickable(By locatorName)
        {
            waitTillElementIsDisplayed(locatorName);
            waitTillElementIsClickable(locatorName);
        }

        public void scrollToWebElement(By locatorName)
        {
            IWebElement element = driver.FindElement(locatorName);
            ((IJavaScriptExecutor)driver).ExecuteScript(
                "arguments[0].scrollIntoView(true);",
                element
            );
        }

        public void scrollToBottom()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,-350)", "");
        }

        public void waitTillURLContains(String textWithInURL)
        {
            wait().Until(ExpectedConditions.UrlContains(textWithInURL));
        }

        public void waitTillElementIsInvisible(By locatorName)
        {
            wait().Until(ExpectedConditions.InvisibilityOfElementLocated(locatorName));
        }

        public void scrollTillTop()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, -200)");
        }

        public String getCurrentURL()
        {
            return driver.Url;
        }

        public void hoverToProduct()
        {
            elementToBeDisplayedOrClickable(acceptAllButton);
            driver.FindElement(acceptAllButton).Click();
            actionItem().MoveToElement(driver.FindElement(workProduct)).Build().Perform();
            driver.FindElement(productBuyButton).Click();
        }

        public Boolean buyButtonDisplaying()
        {
            return driver.FindElement(productBuyButton).Displayed;
        }

        public void clickOnBuyButton()
        {
            driver.FindElement(productBuyButton).Click();
        }

        public void clickOnCartButton()
        {
            elementToBeDisplayedOrClickable(cartButton);
            driver.FindElement(cartButton).Click();
        }

        public void clickOnGoToPaymentButton()
        {
            elementToBeDisplayedOrClickable(goToPaymentButton);
            driver.FindElement(goToPaymentButton).Click();
        }

        public void discountedItemShouldBeDisplaying(String discountedRateItem)
        {
            String discountedRateItemXpath = "//p[normalize-space()='" + discountedRateItem + "']";
            By discountedRateItemLocator = By.XPath(discountedRateItemXpath);
            Boolean discountedRateItemVisibility = driver
                .FindElement(discountedRateItemLocator)
                .Displayed;
            Assert.That(discountedRateItemVisibility, Is.EqualTo(true));
        }
    }
}
