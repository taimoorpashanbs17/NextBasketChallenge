Feature: Order Functionality With Different Scenarios

    Scenario: Verify Search Functionality working fine
        Given Open Browser with provided URL
        When User enters data within search field
            | search_data |
            | Work        |
        Then App should display the results accordingly


    Scenario: Verify Filters with Price works fine
        Given Open Browser with provided URL
        When User clicks on Internal Link Tab
        Then App should navigate user to Internal Page
        And Filters should be displaying with multiple options
        When Add Min and Max value on particular fields
            | min | max  |
            | 200 | 1234 |
        Then Click on Apply Button
        And App should display of results of filters accordingly


    Scenario: Verify Out of stock product should not display 'Buy' Button
        Given Open Browser with provided URL
        When Hover to out of stock product
        Then Buy Button should not be displaying

    Scenario: Verify that 'Clear Out' functionality works fine
        Given Open Browser with provided URL
        When User clicks on Internal Link Tab
        Then App should navigate user to Internal Page
        When Add Min and Max value on particular fields
            | min | max  |
            | 200 | 1234 |
        And Click on Apply Button
        Then App should display of results of filters accordingly
        When Click on Clear Out Button
        Then App should display all results

    Scenario: Veriy that Sort by 'Price Asc.' displays the results accordingly.
        Given Open Browser with provided URL
        When User clicks on Internal Link Tab
        Then App should navigate user to Internal Page
        When User clicks on 'Price Asc.' from Sort Of drop down
        Then App should display the results accordingly

    Scenario: Verify that 'Filter By' functionality should be working fine.
        Given Open Browser with provided URL
        When User clicks on Internal Link Tab
        Then App should navigate user to Internal Page
        When User clicks on any Filter option.
            | Filter By |
            | New       |
        Then App should display the results as per that

    Scenario: Verify that Number of products mentioned on top , should be same as mentioned at Bottom
        Given Open Browser with provided URL
        When User clicks on Internal Link Tab
        Then App should navigate user to Internal Page
        When User clicks on any Filter option.
            | Filter By |
            | New       |
        Then App should display number of products same on both top and Bottom.

    Scenario: Verify every on-stock product should display 'Buy' Button
        Given Open Browser with provided URL
        When Hover to on stock product
        Then 'Buy' Button should be displaying

    Scenario: Verify when searching with invalid data, app should display 'Page not Found'
        Given Open Browser with provided URL
        When User enters data within search field
            | search_data  |
            | InValid Data |
        Then App should display the results 'Page not Found' message

    Scenario: Verify when user add any product to 'Wishlist', app should add that product there.
        Given Open Browser with provided URL
        When Hover to any stock product
        When Click on Heart Shape image within a product
        Then App should add that product within Wishlist section