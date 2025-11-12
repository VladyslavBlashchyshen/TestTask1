using FluentAssertions;
using TestTask.Actions;
using TestTask.Pages;

namespace TestTask.StepDefinitions;

[Binding]
public class LoginSteps
{
    private readonly TestContext _context;
    private readonly LoginPage _loginPage;
    private readonly LoginActions _loginActions;

    public LoginSteps(TestContext context)
    {
        _context = context;
        _loginPage = new LoginPage(_context);
        _loginActions = new LoginActions(_loginPage);
    }

    [Given("I am not logged in with a genuine user")]
    public void GivenIAmNotLoggedInWithAGenuineUser()
    {
        _context.Driver.Url.Should().Contain("/login");
    }

    [When("I navigate to any page on the tracking site")]
    public void WhenINavigateToAnyPageOnTheTrackingSite()
    {
        _context.Driver.Navigate().GoToUrl("/someprotectedpage");
    }

    [Then("I am on the login page")]
    [Given("I am on the login page")]
    public void GivenIAmOnTheLoginPage()
    {
        _context.Driver.Url.Should().Contain("/login");
    }

    [Then("I am logged in successfully")]
    public void ThenIAmLoggedInSuccessfully()
    {
        _context.Driver.Url.Should().Contain("/dashboard");
    }

    [When("I am logged in as '(.*)' user with '(.*)' password")]
    [Given("I am logged in as '(.*)' user with '(.*)' password")]
    public void IAmLoggedInAsUserWithPassword(string userName, string password)
    {
        _loginActions.LoginAs(userName, password);
    }
}

