namespace TestTask.Extensions
{
    public static class WebElementExtensions
    {

        public static void ClearAndSendKeys(this IWebElement element, object inputValue)
        {
            element.Clear();
            element.SendKeys(inputValue.ToString() ?? string.Empty);
        }
    }
}
