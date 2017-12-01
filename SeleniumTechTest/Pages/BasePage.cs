using OpenQA.Selenium;

namespace SeleniumTechTest.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver; // initialize driver
        }
        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url); //navigate to custom url
        }
    }
}
