using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProjectKesley.PageObjects;

public class Page
{
    private const int Seconds = 30;
    
    protected void WaitForElementClickable(IWebDriver driver, By locator)
    {
        new WebDriverWait(driver, TimeSpan.FromSeconds(Seconds)).Until(webDriver => webDriver.FindElement(locator));

    }

    protected void WaitForElementClickable(IWebDriver driver, IWebElement element)
    {
        new WebDriverWait(driver, TimeSpan.FromSeconds(Seconds)).Until(ExpectedConditions.ElementToBeClickable(element));

    }

    protected void WaitForElementsVisible(IWebDriver driver, By locator)
    {
        new WebDriverWait(driver, TimeSpan.FromSeconds(Seconds)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));

    }
    
    protected static void WaitForPageLoad(IWebDriver driver)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        wait.Until(webDriver => ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));
    }
    
    protected void SwitchToIframe(IWebDriver driver, string iframeName)
    {
        driver.SwitchTo().Frame(iframeName);
    }

    protected IWebElement FindElement(IWebDriver driver, By el)
    {
        return driver.FindElement(el);
    }
    protected ReadOnlyCollection<IWebElement> FindElements(IWebDriver driver, By xPath)
    {
        return driver.FindElements(xPath);
    }
    
    protected void Click(IWebDriver driver, By xPath)
    {
        driver.FindElement(xPath).Click();
    }
    protected void FocusBody(IWebDriver driver)
    {
        driver.FindElement(By.XPath("//body")).Click();
    }
    protected void Click(IWebElement webElement)
    {
        webElement.Click();
    }
    protected IWebElement GetDisplayedElement(IWebDriver webDriver, By xpath)
    {
        return FindElements(webDriver, xpath).First(x => x.Displayed);
    }
}