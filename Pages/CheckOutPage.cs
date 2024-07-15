using OpenQA.Selenium;

namespace NextBasketChallenge.Pages
{
    public class CheckOutPage : BasePage
    {
        private readonly IWebDriver driver;

        public CheckOutPage(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver;
        }

        readonly By NameField = By.Name("shippingAddress.firstName");
        readonly By SurnameField = By.Name("shippingAddress.lastName");

        readonly By PhoneNumberField = By.Name("shippingAddress.phone");

        readonly By CountryDropDownField = By.XPath("//div[@data-testid='countryField']//input");
        readonly By CityDropDownField = By.XPath("//div[@data-testid='googleAutocomplete']//input");
        readonly By PostCodeField = By.Name("shippingAddress.postCode");
        readonly By AddressField = By.Name("shippingAddress.address");
        readonly By ConfirmOrderButton = By.XPath("//button//p[normalize-space()='Confirm order']");
        readonly By GoogleMap = By.XPath("//div[@aria-label='Map']");

        public void EnterName(string name)
        {
            WaitTillElementToBeDisplayedAndClickable(NameField);
            EnterText(NameField, name);
        }

        public void EnterSurName(string sureName)
        {
            EnterText(SurnameField, sureName);
        }

        public void EnterPhoneNumber(string phoneNumber)
        {
            EnterText(PhoneNumberField, phoneNumber);
        }

        public void SelectValueFromAutoSelectDropDown(By locator, string valueToSelect)
        {
            WaitTillElementToBeDisplayedAndClickable(locator);
            ClickElement(locator);
            ClearElement(locator);
            EnterText(locator, valueToSelect);
            string valueXpath = "//p[normalize-space()='" + valueToSelect + "']";
            By valueLocator = By.XPath(valueXpath);
            WaitTillElementToBeDisplayedAndClickable(valueLocator);
            ClickElement(valueLocator);
        }

        public void SelectCountry(string countryName)
        {
            SelectValueFromAutoSelectDropDown(CountryDropDownField, countryName);
        }

        public void SelectCity(string cityName)
        {
            SelectValueFromAutoSelectDropDown(CityDropDownField, cityName);
        }

        public void EnterPostCodeNumber(string postCodeNumber)
        {
            WaitTillElementToBeDisplayedAndClickable(PostCodeField);
            ScrollToWebElement(PostCodeField);
            EnterText(PostCodeField, postCodeNumber);
        }

        public void EnterAddress(string address)
        {
            WaitTillElementToBeDisplayedAndClickable(AddressField);
            EnterText(AddressField, address);
        }

        public void ClickOnConfirmPaymentButton()
        {
            ScrollTillTop();
            WaitTillElementToBeDisplayedAndClickable(GoogleMap);
            WaitTillElementToBeDisplayedAndClickable(ConfirmOrderButton);
            ClickElement(ConfirmOrderButton);
        }
    }
}
