using NUnit.Framework;
using OpenQA.Selenium;

namespace NextBasketChallenge.Pages
{
    public class HomePage : BasePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver) :base(driver)
        {
            this.driver = driver;
        }

        readonly By WorkProduct = By.XPath("//img[@alt='Work']");
        readonly By AcceptAllButton = By.XPath("//*[@id='root']/div[1]/div/div[2]/button[1]");

        readonly By ProductBuyButton = By.XPath("//button[@aria-label='Add to basket Work']");

        readonly By CartButton = By.XPath(
            "//button[@aria-label='Open basket menu']//div[@class='gIvgG']//*[name()='svg']"
        );

        readonly By GoToPaymentButton = By.XPath("//p[normalize-space()='Go to payment']");

        public void HoverToProduct()
        {
            WaitTillElementToBeDisplayedAndClickable(AcceptAllButton);
            ClickElement(AcceptAllButton);
            MoveToElementAndPerform(WorkProduct);
            ActionItem().MoveToElement(driver.FindElement(WorkProduct)).Build().Perform();
            ClickElement(ProductBuyButton);
        }

        public bool BuyButtonDisplaying()
        {
            return ElementIsDisplaying(ProductBuyButton);
        }

        public void ClickOnBuyButton()
        {
            ClickElement(ProductBuyButton);
        }

        public void ClickOnCartButton()
        {
            WaitTillElementToBeDisplayedAndClickable(CartButton);
            ClickElement(CartButton);
        }

        public void ClickOnGoToPaymentButton()
        {
            WaitTillElementToBeDisplayedAndClickable(GoToPaymentButton);
            ClickElement(GoToPaymentButton);
        }

        public void DiscountedItemShouldBeDisplaying(string discountedRateItem)
        {
            string discountedRateItemXpath = "//p[normalize-space()='" + discountedRateItem + "']";
            By discountedRateItemLocator = By.XPath(discountedRateItemXpath);
            bool discountedRateItemVisibility = ElementIsDisplaying(discountedRateItemLocator);
            Assert.That(discountedRateItemVisibility, Is.EqualTo(true));
        }
    }
}
