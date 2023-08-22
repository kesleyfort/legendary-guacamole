using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SpecFlowProjectKesley.PageObjects;

public class ConsultasPage : Page
{
    private readonly IWebDriver _webDriver;

    private readonly string _botaoXpath = "//button[span[text()='{0}']]";

    private readonly List<string> _filtrosLabels = new()
        { "Agregação espacial", "Subsistema", "Bacia", "Rio", "Grandeza", "Periodicidade", "Objeto", "Origem" };

    private readonly By _filtrosSelecionadosXpath =
        By.XPath("//angular2-multiselect[descendant::div[@class='c-list ng-star-inserted']]");

    private readonly By _filtrosSelectsBy = By.XPath("//mat-form-field");
    private readonly By _tabelaResultadosTable = By.XPath("//table[@mat-table]");
    private readonly By _listaCheckboxResultadosTable = By.XPath("//td[mat-checkbox]");
    private readonly string _multiSelectOptionXpath = "//li[child::label[text()='{0}']]";
    private readonly string _multiSelectXpath = "//ons-multi-select[@label='{0}']";
    private readonly string _baseCheckBox = "//mat-checkbox[descendant::label[contains(., '{0}')]]";

    private readonly string _opcaoSelecionadaFiltroXpath =
        "//ons-multi-select[@label='{0}']/descendant::span[text()='{1}']";

    private const string Iframe = "viewer";

    public ConsultasPage(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    private ReadOnlyCollection<IWebElement> FiltrosSelects => _webDriver.FindElements(By.XPath("//mat-form-field"));

    public void IsMainPageLoaded()
    {
        WaitForPageLoad(_webDriver);
        WaitForElementsVisible(_webDriver, By.Id(Iframe));
        SwitchToIframe(_webDriver, Iframe);
        WaitForElementsVisible(_webDriver, _filtrosSelectsBy);
        Assert.IsTrue(FiltrosSelects.Count > 0, "Filtros não estão sendo exibidos");
    }

    public void ValidateFiltersVisibility()
    {
        var notDisplayedLabels = _filtrosLabels.Where(label =>
        {
            var xpath = string.Format(_multiSelectXpath, label);
            var el = FindElement(_webDriver, By.XPath(xpath));
            return !el.Displayed;
        });

        Assert.IsFalse(notDisplayedLabels.Any(),
            $"Os campos {string.Join(", ", notDisplayedLabels)} não estão sendo exibidos");
    }

    public void SelectOption(string optionName, string fieldName)
    {
        try
        {
            // Find the multi-select element for the specified field
            var multiSelectXpath = string.Format(_multiSelectXpath, fieldName);
            var multiSelectElement = FindElement(_webDriver, By.XPath(multiSelectXpath));

            // Click on the multi-select element to open the options list
            multiSelectElement.Click();

            // Find the desired option in the options list
            var optionXpath = string.Format(_multiSelectOptionXpath, optionName);
            var optionElement = FindElement(_webDriver, By.XPath(optionXpath));

            // Click on the desired option to select it
            optionElement.Click();
            FocusBody(_webDriver);
        }
        catch (NoSuchElementException ex)
        {
            // Handle cases where elements are not found
            Console.WriteLine("Erro: Elemento não encontrado - " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other errors
            Console.WriteLine("Erro: " + ex.Message);
        }
    }

    public void ValidarOpcaoSelecionada(string opcao, string campo)
    {
        var multiSelectXpath = string.Format(_opcaoSelecionadaFiltroXpath, campo, opcao);
        var multiSelectElement = FindElements(_webDriver, By.XPath(multiSelectXpath));
        FocusBody(_webDriver);
        Assert.IsTrue(multiSelectElement.Count == 1, $"Opção {opcao} não está selecionada no campo {campo}");
    }


    public void ClicarBotao(string botao)
    {
        var xpath = By.XPath(string.Format(_botaoXpath, botao));
        WaitForElementClickable(_webDriver, xpath);
        Click(_webDriver, xpath);
    }

    public void VerificarFiltrosLimpos()
    {
        var els = FindElements(_webDriver, _filtrosSelecionadosXpath).Count;
        Assert.IsTrue(els == 0, "Filtros não foram limpados após clicar no botão \"Limpar Filtros\"");
    }

    public void SelecionarBase(string baseDados)
    {
        FocusBody(_webDriver);
        var xpath = By.XPath(string.Format(_baseCheckBox, baseDados));
        WaitForElementClickable(_webDriver, xpath);
        Click(_webDriver, xpath);
    }

    public void ValidarListaResultados()
    {
        WaitForElementsVisible(_webDriver, _tabelaResultadosTable);
        var els = FindElements(_webDriver, _tabelaResultadosTable).Count;
        Assert.IsTrue(els == 1, "Tabela de resultados não está sendo exibida");
    }

    public void SelecionoSerie(int pos)
    {
        var els = FindElements(_webDriver, _listaCheckboxResultadosTable)[pos - 1];
        WaitForElementClickable(_webDriver, els);
        Click(els);
    }


}