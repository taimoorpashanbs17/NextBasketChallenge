Feature: Order Functionality - Bugs

    Scenario: Verify that Scrolling Price Range should display right amount of price on both price text fields
        Given Open Browser with provided URL
        When User clicks on Internal Link Tab
        Then App should navigate user to Internal Page
        And Go to Price Slider.
        When Scroll the slider to increase the price.
        Then App should display the results accordingly on prices text fields.

    Scenario: Verify that on mentioning min amount on min field, should display the results starting from min value till last limit amount product
        Given Open Browser with provided URL
        When User clicks on Internal Link Tab
        Then App should navigate user to Internal Page
        When Add amount in Price in Min Field
            | amount |
            | 12     |
        And Clear field of Max Field
        Then App should display the results starting from Min price till last amount

