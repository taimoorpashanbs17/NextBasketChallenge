using NextBasketChallenge.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace MyNamespace
{
    [Binding]
    public class NewFeatureStepDefinations
    {
        private IWebDriver driver;
        HomePage homePage;
        ShippingPage shippingPage;
        CheckOutPage checkOutPage;
        OrderSuccessPage orderSuccessPage;

        public NewFeatureStepDefinations(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Open Browser with provided URL")]
        public void GivenOpenBrowserwithprovidedURL()
        {
            driver.Url = "https://teststoreforsouthafri.nextbasket.shop/";
        }

        [When(@"Hover to non-promo product")]
        public void WhenHovertononpromoproduct()
        {
            homePage = new HomePage(driver);
            homePage.HoverToProduct();
        }

        [Then(@"Buy Button should be displaying")]
        public void ThenBuyButtonshouldbedisplaying()
        {
            Assert.That(homePage.BuyButtonDisplaying(), Is.True);
        }

        [Then(@"Click on Buy Button")]
        public void GivenClickonBuyButton()
        {
            homePage.ClickOnBuyButton();
        }

        [Then(@"Click on Cart Button")]
        public void ThenClickonCartButton()
        {
            homePage.ClickOnCartButton();
        }

        [Then(@"Click on 'Go to Payment' Button")]
        public void GivenClickonGotoPaymentButton()
        {
            homePage.ClickOnGoToPaymentButton();
        }

        [Then(@"Browser should navigate to Login Page")]
        public void GivenBrowsershouldnavigatetoLoginPage()
        {
            shippingPage = new ShippingPage(driver);
            shippingPage.EnterEmailAddress("testing@uo.com");
            shippingPage.ClickOnContinueAsGuestButton();
        }

        [Then(@"Register user with Shopping with Guest.")]
        public void GivenRegisteruserwithShoppingwithGuest()
        {
            checkOutPage = new CheckOutPage(driver);
            checkOutPage.EnterName("Taimoor");
            checkOutPage.EnterSurName("Pasha");
            checkOutPage.EnterPhoneNumber("+92321487676");
            checkOutPage.SelectCountry("South Africa");
            checkOutPage.SelectCity("Alberton");
            checkOutPage.EnterPostCodeNumber("54770");
            checkOutPage.EnterAddress("House 416 , 897 Avenue Road");
        }

        [Then(@"Click on 'Confirm Order' Button")]
        public void ThenClickonConfirmOrderButton()
        {
            checkOutPage.ClickOnConfirmPaymentButton();
        }

        [Then(@"User should be navigated to 'Success' Page")]
        public void ThenUsershouldbenavigatedtoSuccessPage()
        {
            orderSuccessPage = new OrderSuccessPage(driver);
            orderSuccessPage.VerifyURLContainsSuccess();
        }

        [Then(@"'Thanks' Message should be displayed")]
        public void GivenThanksMessageshouldbedisplayed()
        {
            orderSuccessPage.VerifyThankYouHeaderDisplaying();
        }

        [Then(@"Web should display a product with -50% off label")]
        public void ThenWebshoulddisplayaproductwithofflabel()
        {
            homePage = new HomePage(driver);
            homePage.DiscountedItemShouldBeDisplaying("-50 %");
        }
    }
}
