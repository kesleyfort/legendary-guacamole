using NUnit.Framework;
using OpenQA.Selenium;

namespace SpecFlowProjectKesley.PageObjects;

public class ModalExportarPage : Page
{
    private readonly IWebDriver _webDriver;
    private readonly By _anosFuturosCalendarioXpath = By.XPath("//button[@aria-label='Next 24 years']");
    private readonly By _anosAnterioresCalendarioXpath = By.XPath("//button[@aria-label='Previous 24 years']");
    private readonly By doneCalendarButton = By.XPath("//button[descendant::mat-icon[text()='done']]");
    private readonly string _mensagemErroXpath = "//label[contains(text(),'{0}')]";
    private readonly List<string> PadraoDiarioCampos = new() { "Nome", "Data inicial", "Data final" };

    private readonly List<string> PadraoMensalCampos = new() { "Nome", "Data inicial", "Data final" };
    private readonly List<string> VazoesMensaisCampos = new() { "Nome", "DAT", ".txt", "Ano inicial", "Data final" };
    private readonly List<string> VazpastCampos = new() { "Nome", "Data" };

    public ModalExportarPage(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    private IWebElement modalExportacaoModal => _webDriver.FindElement(By.XPath("//app-modal-export"));
    private By SelecionarAnoMesButtonXpath => By.XPath("//button[@aria-label='Choose month and year']");
    private string _abaModalExportacao => "//mat-expansion-panel[descendant::label[contains(text(), '{0}')]]";

    private string InputXpath =>
        "//mat-expansion-panel[mat-expansion-panel-header[descendant::label[contains(.,'{0}')]]]/descendant::mat-form-field[descendant::label[contains(.,'{1}')]]//input";

    private string DateXpath =>
        "//mat-form-field[preceding::label[contains(.,'{0}')] and descendant::strong[contains(.,'{1}')]]/descendant::mat-datepicker-toggle";

    public By AnoDiaCalendarXpath => By.XPath("//div[contains(@class,'mat-calendar-body-cell-content')]");

    public void ValidarModalExportacao()
    {
        WaitForElementClickable(_webDriver, modalExportacaoModal);
        Assert.IsTrue(modalExportacaoModal.Displayed, "Modal não está sendo exibido");
    }

    public void ValidarAba(string aba)
    {
        var xpath = By.XPath(string.Format(_abaModalExportacao, aba));
        WaitForElementClickable(_webDriver, xpath);
        Assert.IsTrue(FindElement(_webDriver, xpath).Displayed, "Aba não está sendo exibido");
    }

    public void PreencherCampo(string campo, string aba, string valor)
    {
        if (campo.ToLower().Contains("data"))
        {
            SelectDate(campo, aba, valor);
        }
        else
        {
            var xpath = By.XPath(string.Format(InputXpath, aba, campo));
            var el = FindElement(_webDriver, xpath);
            WaitForElementClickable(_webDriver, el);
            el.Clear();
            el.SendKeys(valor);
        }
    }

    private void SelectDate(string campo, string aba, string valor)
    {
        var partesData = valor.Split("/");
        string dia = "";
        string mes;
        string ano;
        if (partesData.Length == 3)
        {
            dia =         partesData[0];
            mes =         partesData[1];
            ano =         partesData[2];

        }
        else
        {
            mes =         partesData[0];
            ano = partesData[1];
        }
        
        var calendarioBtn = By.XPath(string.Format(DateXpath, aba, campo));
        var el = FindElement(_webDriver, calendarioBtn);
        WaitForElementClickable(_webDriver, el);
        el.Click();
        var selecionarAnoMesBtn = FindElement(_webDriver, SelecionarAnoMesButtonXpath);
        WaitForElementClickable(_webDriver, selecionarAnoMesBtn);
        selecionarAnoMesBtn.Click();
        var valoresAnos = FindElements(_webDriver, AnoDiaCalendarXpath);
        while (!valoresAnos.Any(x => x.Text.Contains(ano)))
        {
            if (int.Parse(valoresAnos.Last().Text) > int.Parse(ano))
            {
                Click(_webDriver, _anosAnterioresCalendarioXpath);
            }
            else
            {
                Click(_webDriver, _anosFuturosCalendarioXpath);
            }

            valoresAnos = FindElements(_webDriver, AnoDiaCalendarXpath);
        }
        FindElements(_webDriver, AnoDiaCalendarXpath).First(x => x.Text.Contains(ano)).Click();
        var mesPos = int.Parse(mes) - 1;
        FindElements(_webDriver, AnoDiaCalendarXpath)[mesPos].Click();
        if (dia.Length > 0)
        {
            var days = FindElements(_webDriver, AnoDiaCalendarXpath);
            WaitForElementClickable(_webDriver, AnoDiaCalendarXpath);
            days[int.Parse(dia) -1].Click();
        }
        else
        {
            var days = FindElement(_webDriver, AnoDiaCalendarXpath);
            WaitForElementClickable(_webDriver, days);
            days.Click();
        }
        
        FindElement(_webDriver, doneCalendarButton).Click();
    }


    public void ValidarCampo(string campo, string aba, string valor)
    {
        var xpath = By.XPath(string.Format(InputXpath, aba, campo));
        var el = FindElement(_webDriver, xpath);
        WaitForElementClickable(_webDriver, el);
        var text = el.GetAttribute("value");
        Assert.AreEqual(valor, text,
            $"Valor no campo é diferente do valor esperado. Esperado: {valor} Encontrado: {text}");
    }

    public void AbrirAba(string aba)
    {
        var xpath = By.XPath(string.Format(_abaModalExportacao, aba));
        WaitForElementClickable(_webDriver, xpath);
        Click(_webDriver, xpath);
    }

    public void ValidarCamposVisiveis(string aba)
    {
        switch (aba.ToLower())
        {
            case "padrão mensal":
            {
                foreach (var nome in PadraoMensalCampos)
                {
                    var xpath = By.XPath(string.Format(InputXpath, aba, nome));
                    var el = FindElement(_webDriver, xpath);
                    WaitForElementClickable(_webDriver, el);
                    Assert.IsTrue(el.Displayed, $"Elemento {nome} não está visível");
                }

                break;
            }
            case "vazões mensais":
            {
                foreach (var nome in VazoesMensaisCampos)
                {
                    var xpath = By.XPath(string.Format(InputXpath, aba, nome));
                    var el = FindElement(_webDriver, xpath);
                    WaitForElementClickable(_webDriver, el);
                    Assert.IsTrue(el.Displayed, $"Elemento {nome} não está visível");
                }

                break;
            }
            case "vazpast":
            {
                foreach (var nome in VazpastCampos)
                {
                    var xpath = By.XPath(string.Format(InputXpath, aba, nome));
                    var el = FindElement(_webDriver, xpath);
                    WaitForElementClickable(_webDriver, el);
                    Assert.IsTrue(el.Displayed, $"Elemento {nome} não está visível");
                }

                break;
            }
            case "padrão diário":
            {
                foreach (var nome in PadraoDiarioCampos)
                {
                    var xpath = By.XPath(string.Format(InputXpath, aba, nome));
                    var el = FindElement(_webDriver, xpath);
                    WaitForElementClickable(_webDriver, el);
                    Assert.IsTrue(el.Displayed, $"Elemento {nome} não está visível");
                }

                break;
            }
        }
    }


    #region VazoesMensais

    private IWebElement VazoesMensaisNome => _webDriver.FindElement(By.Id("vazoesMensaisNome"));
    private IWebElement VazoesMensaisDat => _webDriver.FindElement(By.Id("vazoesMensaisExtDat-input"));
    private IWebElement VazoesMensaisTxt => _webDriver.FindElement(By.Id("vazoesMensaisExtTxt-input"));
    private IWebElement VazoesMensaisAnoInicial => _webDriver.FindElement(By.Id("vazoesMensaisAnoInicial"));
    private IWebElement VazoesMensaisAnoFinal => _webDriver.FindElement(By.Id("vazoesMensaisDataFinal"));

    #endregion

    public void ValidarMensagemErro(string mensagem)
    {
        var xpath = By.XPath(string.Format(_mensagemErroXpath, mensagem));
        var el = FindElement(_webDriver, xpath);
        WaitForElementClickable(_webDriver, el);
        var text = el.Text;
        Assert.AreEqual(mensagem, text,
            $"Valor no campo é diferente do valor esperado. Esperado: {mensagem} Encontrado: {text}");
    }
}