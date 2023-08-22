using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProjectKesley.Drivers
{
    public class Driver
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        public Driver()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }
        public IWebDriver Current => _currentWebDriverLazy.Value;
        
        private IWebDriver CreateWebDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("incognito", "start-maximized");
            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
            return chromeDriver;
        }
        
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }
    }
}