using NUnit.Framework;
using OpenQA.Selenium;

namespace NextBasketChallenge.Pages
{
    public class OrderSuccessPage : BasePage
    {
        private readonly IWebDriver driver;

        readonly By ThankYouMessage = By.TagName("h1");

        public OrderSuccessPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void VerifyURLContainsSuccess()
        {
            WaitTillURLContains("success");
            string successURL = GetCurrentURL();
            Assert.That(successURL.Contains("success"), Is.EqualTo(true));
        }

        public void VerifyThankYouHeaderDisplaying()
        {
            bool ThankYouHeaderDisplaying = ElementIsDisplaying(ThankYouMessage);
            Assert.That(ThankYouHeaderDisplaying, Is.EqualTo(true));
        }
    }
}
