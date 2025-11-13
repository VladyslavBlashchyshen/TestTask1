using TestTask.Pages;

namespace TestTask.Actions;

public class LoginActions
{
    private readonly LoginPage _loginPage;

    public LoginActions(LoginPage loginPage)
    {
        _loginPage = loginPage;
    }

    public void LoginAs(string username, string password)
    {
        _loginPage.LoginBlock.EnterUsername(username);
        _loginPage.LoginBlock.EnterPassword(password);
        _loginPage.LoginBlock.ClickLogin();
    }
}