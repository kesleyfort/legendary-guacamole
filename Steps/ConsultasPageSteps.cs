using SpecFlowProjectKesley.Drivers;
using SpecFlowProjectKesley.PageObjects;

namespace SpecFlowProjectKesley.Steps;

[Binding]
public class ConsultasPageSteps
{
    private readonly ConsultasPage _consultasPage;

    public ConsultasPageSteps(Driver browserDriver, ScenarioContext scenarioContext)
    {
        _consultasPage = new ConsultasPage(browserDriver.Current);
    }

    [Then(@"devo ver a tela inicial do sistema")]
    public void ThenDevoVerATelaInicialDoSistema()
    {
        _consultasPage.IsMainPageLoaded();
    }

    [Then(@"ver todos os campos de filtros")]
    public void ThenVerTodosOsCamposDeFiltros()
    {
        _consultasPage.ValidateFiltersVisibility();
    }

    [When(@"seleciono a opção ""(.*)"" no campo ""(.*)""")]
    public void WhenSelecionoAOpcaoNoCampo(string opcao, string campo)
    {
        _consultasPage.SelectOption(opcao, campo);
    }

    [Then(@"devo ver a opção ""(.*)"" no campo ""(.*)""")]
    public void ThenDevoVerAOpcaoNoCampo(string opcao, string campo)
    {
        _consultasPage.ValidarOpcaoSelecionada(opcao, campo);
    }

    [When(@"clico no botão ""(.*)""")]
    public void WhenClicoNoBotao(string botao)
    {
        _consultasPage.ClicarBotao(botao);
    }

    [Then(@"devo ver os filtros limpos")]
    public void ThenDevoVerOsFiltrosLimpos()
    {
        _consultasPage.VerificarFiltrosLimpos();
    }

    [When(@"seleciono a base ""(.*)""")]
    public void WhenSelecionoABase(string baseDados)
    {
        _consultasPage.SelecionarBase(baseDados);
    }

    [Then(@"o sistema deve mostrar a lista de resultados")]
    public void ThenOSistemaDeveMostrarAListaDeResultados()
    {
        _consultasPage.ValidarListaResultados();
    }

    [When(@"seleciono a série na posição ""(.*)""")]
    public void WhenSelecionoASerieNaPosicao(int pos)
    {
        _consultasPage.SelecionoSerie(pos);
    }
}