using TestTask.Extensions;

namespace TestTask.Pages.Blocks;

public class LoginBlock
{
    private readonly IWebElement _element;

    public LoginBlock(IWebElement element)
    {
        _element = element;
    }

    private IWebElement UsernameInput => _element.FindElement(By.Id("username"));
    private IWebElement PasswordInput => _element.FindElement(By.Id("password"));
    private IWebElement LoginButton => _element.FindElement(By.Id("login"));

    public void EnterUsername(string username)
    {
        UsernameInput.ClearAndSendKeys(username);
    }

    public void EnterPassword(string password)
    {
        PasswordInput.ClearAndSendKeys(password);
    }

    public void ClickLogin()
    {
        LoginButton.Click();
    }
}