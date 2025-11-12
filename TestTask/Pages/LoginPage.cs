using TestTask.Pages.Blocks;

namespace TestTask.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;

    public LoginPage(TestContext context)
    {
        _driver = context.Driver;
    }

    public LoginBlock LoginBlock => new(_driver.FindElement(By.Id("LoginBLock")));
}