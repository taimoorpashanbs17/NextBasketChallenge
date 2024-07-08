using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace NextBasketChallenge.Pages
{
    public class OrderSuccessPage : HomePage
    {
        private IWebDriver driver;

        public OrderSuccessPage(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver;
        }

        By thankYouMessage = By.TagName("h1");

        public void verifyURLContainsSuccess()
        {
            waitTillURLContains("success");
            String successURL = getCurrentURL();
            Assert.That(successURL.Contains("success"), Is.EqualTo(true));
        }

        public void verifyThankYouHeaderDisplaying()
        {
            Boolean thankYouHeaderDisplaying = driver.FindElement(thankYouMessage).Displayed;
            Assert.That(thankYouHeaderDisplaying, Is.EqualTo(true));
        }
    }
}
