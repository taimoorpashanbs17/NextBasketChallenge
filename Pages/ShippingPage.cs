using System;
using OpenQA.Selenium;

namespace NextBasketChallenge.Pages
{
    public class ShippingPage : HomePage
    {
        private IWebDriver driver;

        By emailField = By.Name("email");
        By continueAsGuestButton = By.XPath(
            "//button[contains(@class,'Button_btn__dhQun GradientButton_button__FqMH9 GuestForm_login__button__XH_xd Button_btn__default__gLEh_ Button_btn__text__EEZSK')]"
        );

        public ShippingPage(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver;
        }

        public void enterEmailAddress(String emailAdreess)
        {
            elementToBeDisplayedOrClickable(emailField);
            driver.FindElement(emailField).SendKeys(emailAdreess);
        }

        public void clickOnContinueAsGuestButton()
        {
            elementToBeDisplayedOrClickable(continueAsGuestButton);
            driver.FindElement(continueAsGuestButton).Click();
        }
    }
}
