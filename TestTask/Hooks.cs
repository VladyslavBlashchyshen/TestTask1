using TestTask.Drivers;

namespace TestTask;

[Binding]
public class Hooks 
{
    private readonly TestContext _testContext;
    private readonly WebDriverManager _webDriverManager;

    public Hooks(TestContext testContext, WebDriverManager webDriverManager)
    {
        _testContext = testContext;
        _webDriverManager = webDriverManager;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        _testContext.Driver = _webDriverManager.Driver;
        _testContext.Driver.Navigate().GoToUrl("https://site.com");
    }

    [AfterScenario]
    public void AfterScenario()
    {
        _webDriverManager.Quit();
    }
}

