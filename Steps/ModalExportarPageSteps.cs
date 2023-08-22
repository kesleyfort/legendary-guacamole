using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectKesley.Drivers;
using SpecFlowProjectKesley.PageObjects;

namespace SpecFlowProjectKesley.Steps;

[Binding]
public class ModalExportarPageSteps
{
    private readonly ModalExportarPage _modalExportarPage;
    
    public ModalExportarPageSteps(Driver browserDriver, ScenarioContext scenarioContext)
    {
        _modalExportarPage = new ModalExportarPage(browserDriver.Current);
    }


    [Then(@"devo ver o modal de exportação")]
    public void ThenDevoVerOModalDeExportacao()
    {
        _modalExportarPage.ValidarModalExportacao();
    }

    [Then(@"ver a aba ""(.*)""")]
    public void ThenVerAAba(string aba)
    {
        _modalExportarPage.ValidarAba(aba);
    }

    [When(@"preencho o campo ""(.*)"" na aba ""(.*)"" com o valor ""(.*)""")]
    public void WhenPreenchoOCampoNaAbaComOValor(string campo, string aba, string valor)
    {
        _modalExportarPage.PreencherCampo(campo, aba, valor);
    }

    [Then(@"devo ver o valor ""(.*)"" no campo ""(.*)"" na aba ""(.*)""")]
    public void ThenDevoVerOValorNoCampoNaAba(string valor, string campo, string aba)
    {
        _modalExportarPage.ValidarCampo(campo, aba, valor);
    }

    [When(@"clico no aba ""(.*)""")]
    public void WhenClicoNoAba(string aba)
    {
        _modalExportarPage.AbrirAba(aba);
    }

    [Then(@"devo ver os campos da aba ""(.*)""")]
    public void ThenDevoVerOsCamposDaAba(string aba)
    {
        _modalExportarPage.ValidarCamposVisiveis(aba);
    }

    [Then(@"devo ver a mensagem de erro ""(.*)""")]
    public void ThenDevoVerAMensagemDeErro(string mensagem)
    {
        _modalExportarPage.ValidarMensagemErro(mensagem);
    }
}