Feature: Scenario 1 – Barrier to Entry

  Scenario: Redirect to login when not authenticated
    Given  I am not logged in with a genuine user
    When  I navigate to any page on the tracking site
    Then I am on the login page

  Scenario: Successful login with valid credentials
    Given I am on the login page
    When I am logged in as 'ValidUser' user with 'correct' password
    Then I am logged in successfully