using OpenQA.Selenium;

namespace NextBasketChallenge.Pages
{
    public class ShippingPage : BasePage
    {
        private readonly IWebDriver driver;

        readonly By EmailField = By.Name("email");
        readonly By ContinueAsGuestButton = By.XPath(
            "//button[contains(@class,'Button_btn__dhQun GradientButton_button__FqMH9 GuestForm_login__button__XH_xd Button_btn__default__gLEh_ Button_btn__text__EEZSK')]"
        );

        public ShippingPage(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver;
        }

        public void EnterEmailAddress(string emailAdreess)
        {
            WaitTillElementToBeDisplayedAndClickable(EmailField);
            EnterText(EmailField, emailAdreess);
        }

        public void ClickOnContinueAsGuestButton()
        {
            WaitTillElementToBeDisplayedAndClickable(ContinueAsGuestButton);
            ClickElement(ContinueAsGuestButton);
        }
    }
}
