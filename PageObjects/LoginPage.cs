using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowProjectKesley.PageObjects
{
    public class LoginPage : Page
    {
        private readonly IWebDriver _webDriver;
        private readonly string _user;
        private readonly string _password;

        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _user = TestContext.Parameters["user"]!;
            _password = TestContext.Parameters["password"]!;
        }

        private IWebElement LoginInput => _webDriver.FindElement(By.Id("username"));
        private IWebElement PasswordInput => _webDriver.FindElement(By.Id("password"));
        private IWebElement AvancarButton => _webDriver.FindElement(By.Name("submit.IdentificarUsuario"));
        private IWebElement EntrarButton => _webDriver.FindElement(By.Name("submit.Signin"));

        public void Login()
        {
            WaitForElementClickable(_webDriver, LoginInput);
            LoginInput.SendKeys(_user);
            AvancarButton.Click();
            WaitForElementClickable(_webDriver, PasswordInput);
            PasswordInput.SendKeys(_password);
            EntrarButton.Click();
        }

    }
}
