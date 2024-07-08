Feature: Order Functionality

Scenario: Order the first in stock non-promo product (use South Africa as Country and Alberton as City)
    Given Open Browser with provided URL
    When Hover to non-promo product
    Then Buy Button should be displaying
    Then Click on Buy Button
    Then Click on Cart Button
    Then Click on 'Go to Payment' Button
    Then Browser should navigate to Login Page
    Then Register user with Shopping with Guest.
    Then Click on 'Confirm Order' Button
    Then User should be navigated to 'Success' Page
    Then 'Thanks' Message should be displayed

Scenario: Make sure that "50% off" label is visible
    Given Open Browser with provided URL
    Then Web should display a product with -50% off label
