using System;
using OpenQA.Selenium;

namespace NextBasketChallenge.Pages

{
    public class CheckOutPage : HomePage{
        private IWebDriver driver;
        public CheckOutPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        By nameField = By.Name("shippingAddress.firstName");
        By surnameField = By.Name("shippingAddress.lastName");

        By phoneNumberField = By.Name("shippingAddress.phone");

        By countryDropDownField = By.XPath("//div[@data-testid='countryField']//input");
        By cityDropDownField = By.XPath("//div[@data-testid='googleAutocomplete']//input");
        By postCodeField = By.Name("shippingAddress.postCode");
        By addressField = By.Name("shippingAddress.address");
        By confirmOrderButton = By.XPath("//button//p[normalize-space()='Confirm order']");
        By googleMap = By.XPath("//div[@aria-label='Map']");


        public void enterName(String name){
            elementToBeDisplayedOrClickable(nameField);
            driver.FindElement(nameField).SendKeys(name);
        }

        public void enterSurName(String sureName){
            driver.FindElement(surnameField).SendKeys(sureName);
        }

        public void enterPhoneNumber(String phoneNumber){
            driver.FindElement(phoneNumberField).SendKeys(phoneNumber);
        }

        public void selectValueFromAutoSelectDropDown(By locatorName, String valueToSelect){
            elementToBeDisplayedOrClickable(locatorName);
            driver.FindElement(locatorName).Click();
            driver.FindElement(locatorName).Clear();
            driver.FindElement(locatorName).SendKeys(valueToSelect);
            String valueXpath = "//p[normalize-space()='"+valueToSelect+"']";
            By valueLocator = By.XPath(valueXpath);
            elementToBeDisplayedOrClickable(valueLocator);
            driver.FindElement(valueLocator).Click();
        }

        public void selectCountry(String countryName){
            selectValueFromAutoSelectDropDown(countryDropDownField, countryName);
        }

        public void selectCity(String cityName){
            selectValueFromAutoSelectDropDown(cityDropDownField, cityName);
        }

        public void enterPostCodeNumber(String postCodeNumber){
            elementToBeDisplayedOrClickable(postCodeField);
            scrollToWebElement(postCodeField);
            driver.FindElement(postCodeField).SendKeys(postCodeNumber);
        }

        public void enterAddress(String address){
            elementToBeDisplayedOrClickable(addressField);
            driver.FindElement(addressField).SendKeys(address);
        }

        public void clickOnConfirmPaymentButton(){
            scrollTillTop();
            elementToBeDisplayedOrClickable(googleMap);
            elementToBeDisplayedOrClickable(confirmOrderButton);
            driver.FindElement(confirmOrderButton).Click();
        }
    }
}