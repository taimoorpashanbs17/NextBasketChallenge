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
            homePage.hoverToProduct();
        }

        [Then(@"Buy Button should be displaying")]
        public void ThenBuyButtonshouldbedisplaying()
        {
            Assert.That(homePage.buyButtonDisplaying(), Is.True);
        }

        [Then(@"Click on Buy Button")]
        public void GivenClickonBuyButton()
        {
            homePage.clickOnBuyButton();
        }

        [Then(@"Click on Cart Button")]
        public void ThenClickonCartButton()
        {
            homePage.clickOnCartButton();
        }

        [Then(@"Click on 'Go to Payment' Button")]
        public void GivenClickonGotoPaymentButton()
        {
            homePage.clickOnGoToPaymentButton();
        }

        [Then(@"Browser should navigate to Login Page")]
        public void GivenBrowsershouldnavigatetoLoginPage()
        {
            shippingPage = new ShippingPage(driver);
            shippingPage.enterEmailAddress("testing@uo.com");
            shippingPage.clickOnContinueAsGuestButton();
        }

        [Then(@"Register user with Shopping with Guest.")]
        public void GivenRegisteruserwithShoppingwithGuest()
        {
            checkOutPage = new CheckOutPage(driver);
            checkOutPage.enterName("Taimoor");
            checkOutPage.enterSurName("Pasha");
            checkOutPage.enterPhoneNumber("+92321487676");
            checkOutPage.selectCountry("South Africa");
            checkOutPage.selectCity("Alberton");
            checkOutPage.enterPostCodeNumber("54770");
            checkOutPage.enterAddress("House 416 , 897 Avenue Road");
        }

        [Then(@"Click on 'Confirm Order' Button")]
        public void ThenClickonConfirmOrderButton()
        {
            checkOutPage.clickOnConfirmPaymentButton();
        }

        [Then(@"User should be navigated to 'Success' Page")]
        public void ThenUsershouldbenavigatedtoSuccessPage()
        {
            orderSuccessPage = new OrderSuccessPage(driver);
            orderSuccessPage.verifyURLContainsSuccess();
        }

        [Then(@"'Thanks' Message should be displayed")]
        public void GivenThanksMessageshouldbedisplayed()
        {
            orderSuccessPage.verifyThankYouHeaderDisplaying();
        }

        [Then(@"Web should display a product with -50% off label")]
        public void ThenWebshoulddisplayaproductwithofflabel()
        {
            homePage = new HomePage(driver);
            homePage.discountedItemShouldBeDisplaying("-50 %");
        }
    }
}
