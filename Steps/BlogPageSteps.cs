using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectKesley.Drivers;
using SpecFlowProjectKesley.PageObjects;

namespace SpecFlowProjectKesley.Steps;

[Binding]
public class BlogPageSteps
{
    private readonly BlogPage _blogPage;
    private readonly string _homePage;
    private readonly IWebDriver _webDriver;

    public BlogPageSteps(Driver browserDriver, ScenarioContext scenarioContext)
    {
        _blogPage = new BlogPage(browserDriver.Current);
        _homePage = TestContext.Parameters["webAppUrl"]!;
        _webDriver = browserDriver.Current;
    }

    [Given(@"que eu esteja na página do blog agibank")]
    public void GivenQueEuEstejaNaPaginaDoBlogAgibank()
    {
        _webDriver.Navigate().GoToUrl(_homePage);
    }

    [Then(@"devo ver o ícone de buscar")]
    public void ThenDevoVerOIconeDeBuscar()
    {
        _blogPage.ValidateSearchIcon();
    }

    [When(@"clico no ícone de buscar")]
    public void WhenClicoNoIconeDeBuscar()
    {
        _blogPage.ClickSearchIcon();
    }

    [Then(@"devo ver o campo de busca")]
    public void ThenDevoVerOCampoDeBusca()
    {
        _blogPage.ValidateSearchInput();
    }

    [Then(@"devo ver o botão pesquisar")]
    public void ThenDevoVerOBotaoPesquisar()
    {
        _blogPage.ValidateSearchButton();
    }

    [When(@"clico no botão ""(.*)""")]
    public void WhenClicoNoBotao(string button)
    {
        _blogPage.ClickButton(button);
    }

    [Then(@"devo ver a lista de resultados")]
    public void ThenDevoVerAListaDeResultados()
    {
        _blogPage.ValidateArticlesList();
    }

    [When(@"preencho o campo pesquisar com o valor ""(.*)""")]
    public void WhenPreenchoOCampoPesquisarComOValor(string valor)
    {
        _blogPage.FillInput(valor);
    }
}