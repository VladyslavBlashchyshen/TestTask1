using FluentAssertions;
using TestTask.Pages;

namespace TestTask.StepDefinitions;

[Binding]
public class InformationPageSteps
{
    private readonly TestContext _context;
    private readonly InformationPage _informationPage;

    public InformationPageSteps(TestContext context)
    {
        _context = context;
        _informationPage = new InformationPage(_context);
    }

    [Then(@"I see that price is not displayed")]
    public void ThenISeeThatPriceIsDisplayed()
    {
        _informationPage.IsPriceDisplayed().Should().BeFalse();
    }

}

