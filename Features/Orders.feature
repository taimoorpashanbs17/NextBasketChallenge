Feature: Order Functionality

Scenario: Order the first in stock non-promo product (use South Africa as Country and Alberton as City)
    Given Open Browser with provided URL
    When Hover to non-promo product
    Then Buy Button should be displaying
    And Click on Buy Button
    And Click on Cart Button
    And Click on 'Go to Payment' Button
    And Browser should navigate to Login Page
    And Register user with Shopping with Guest.
    And Click on 'Confirm Order' Button
    And User should be navigated to 'Success' Page
    And 'Thanks' Message should be displayed

Scenario: Make sure that "50% off" label is visible
    Given Open Browser with provided URL
    Then Web should display a product with -50% off label
