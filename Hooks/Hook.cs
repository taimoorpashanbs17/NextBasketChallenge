using System.Threading;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace NextBasketChallenge.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }
        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null)
            {
                Thread.Sleep(2000);
                driver.Quit();
            }
        }

    }
}
