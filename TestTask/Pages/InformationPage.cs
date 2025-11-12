namespace TestTask.Pages;

public class InformationPage
{
    private readonly IWebDriver _driver;

    public InformationPage(TestContext context)
    {
        _driver = context.Driver;
    }

    private IWebElement Price => _driver.FindElement(By.Id("price"));

    public string GetPrice() => Price.Text;

    public bool IsPriceDisplayed() => Price.Displayed;
}
