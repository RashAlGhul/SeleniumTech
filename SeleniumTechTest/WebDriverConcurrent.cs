using System;
using System.Collections.Concurrent;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumTechTest
{
    class WebDriverConcurrent
    {
        private static readonly ConcurrentDictionary<Type, IWebDriver> DriverPool = new ConcurrentDictionary<Type, IWebDriver>();//drivers collection for multithreads tests
        private static readonly string CurrentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;//drivers directory

        public static IWebDriver InitDriver(Type type)//drivers initialize
        {
            IWebDriver driver;
            if (!DriverPool.TryGetValue(type, out driver))
            {
                switch (TestData.Driver.ToUpper())
                {
                    case "CHROME":
                        driver = InitChromeDriver();
                        break;
                    case "FIREFOX":
                        driver = InitFirefoxDriver();
                        break;
                    default:
                        driver = InitChromeDriver();
                        break;
                }
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(TestData.ImplicitWaitTime));
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(int.Parse(TestData.PageLoadWaitTime));
                System.Threading.SpinWait.SpinUntil(() => DriverPool.TryAdd(type, driver),
                TimeSpan.FromSeconds(int.Parse(TestData.DriverAddingTimeout)));
            }

            return driver;
        }

        private static IWebDriver InitChromeDriver()//set chome driver options
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("no-sandbox");
            IWebDriver driver = new ChromeDriver(CurrentDirectory, options, TimeSpan.FromMinutes(int.Parse(TestData.BrowserTimeout)));

            return driver;
        }

        private static IWebDriver InitFirefoxDriver()//set firefox  options
        {//!!!It is preferable to use the chrome driver to avoid problems with some elements
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            FirefoxOptions options = new FirefoxOptions();
            IWebDriver driver = new FirefoxDriver(service, options, TimeSpan.FromMinutes(int.Parse(TestData.BrowserTimeout)));
            driver.Manage().Window.Maximize();

            return driver;
        }

        public static void KillDriver(Type type)//remove driver from collection
        {
            DriverPool[type].Quit();
            IWebDriver driver;

            bool isDriverRemoved = false;
            while (!isDriverRemoved)
            {
                isDriverRemoved = DriverPool.TryRemove(type, out driver);
            }
            driver = null;
        }
    }
}
