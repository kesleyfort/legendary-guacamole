using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectKesley.Drivers;
using SpecFlowProjectKesley.PageObjects;

namespace SpecFlowProjectKesley.Steps;

[Binding]
public class LoginPageSteps
{
    private readonly LoginPage _loginPage;
    private IWebDriver _webDriver;
    private String _homePage;
    public LoginPageSteps(Driver browserDriver, ScenarioContext scenarioContext)
    {
        _loginPage = new LoginPage(browserDriver.Current);
        _webDriver = browserDriver.Current;
        _homePage = TestContext.Parameters["webAppUrl"]!;
    }

    [Given(@"que eu esteja na página inicial")]
    public void GivenQueEuEstejaNaPaginaInicial()
    {
        _webDriver.Navigate().GoToUrl(_homePage);
    }

    [When(@"eu logo na aplicação")]
    public void WhenEuLogoNaAplicacao()
    {
        _loginPage.Login();
    }
}