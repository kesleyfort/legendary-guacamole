using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SpecFlowProjectKesley.PageObjects;

public class BlogPage : Page
{
    private readonly IWebDriver _webDriver;
    public readonly By SearchIcon = By.Id("search-open");
    public By SearchInput = By.ClassName("search-field");
    public By SearchButton = By.ClassName("search-submit");
    private By _navBar = By.Id("desktop-navigation");
    private readonly Func<string, By> _buttonXpath = value => By.XPath($"//*[@value='{value}']");
    private By _articleList = By.TagName("article");
    private string _tag;
    private By _searchTag = By.XPath("//h1[@class='archive-title']/span");


    public BlogPage(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public void IsMainPageLoaded()
    {
        WaitForPageLoad(_webDriver);
        WaitForElementsVisible(_webDriver, SearchIcon);
        Assert.IsTrue(FindElement(_webDriver, _navBar).Displayed, "Página inicial não está sendo exibida");
    }

    public void ValidateSearchIcon()
    {
        WaitForElementsVisible(_webDriver, SearchIcon);
        Assert.IsTrue(FindElement(_webDriver, SearchIcon).Displayed, "Botão de buscar não está sendo exibido");
    }

    public void ClickSearchIcon()
    {
        WaitForElementClickable(_webDriver, SearchIcon);
        Click(_webDriver, SearchIcon);
    }

    public void ValidateSearchInput()
    {
        
        var input = GetDisplayedElement(_webDriver, SearchInput);
        Assert.IsTrue(input.Displayed, "Botão de buscar não está sendo exibido");
    }

    public void ValidateSearchButton()
    {
        var btn = GetDisplayedElement(_webDriver, SearchButton);
        Assert.IsTrue(btn.Displayed, "Botão pesquisar não está sendo exibido");
    }

    public void ClickButton(string pesquisar)
    {
        By xpath = _buttonXpath.Invoke(pesquisar);
        var btn = GetDisplayedElement(_webDriver, xpath);
        WaitForElementClickable(_webDriver, btn);
        btn.Click();
    }

    public void ValidateArticlesList()
    {
        var articles = FindElements(_webDriver, _articleList);
        Assert.IsTrue(articles.Count > 0, "Lista de artigos não está sendo exibida");
        if (_tag != null)
        {
            var displayedTag = GetDisplayedElement(_webDriver, _searchTag);
            Assert.IsTrue(_tag.Equals(displayedTag.Text), "A tag pesquisada não está diferente da tag esperada");
        }
        
    }

    public void FillInput(string valor)
    {
        var input = GetDisplayedElement(_webDriver, SearchInput);
        WaitForElementClickable(_webDriver, input);
        input.SendKeys(valor);
        _tag = valor;
    }
}