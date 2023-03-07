using System.Net.Mime;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject1.Drivers;
using NUnit.Framework;

namespace SpecFlowProject1.Hooks;

/*
 * I have written Selenium methods in this class and these Selenium methods do not exist in any other class
 */
public class Methods
{
    WebDriverWait wait = new WebDriverWait(Driver.webDriver, TimeSpan.FromSeconds(10));

    public void click(By by)
    {
        IWebElement element=findElement(by);
        element.Click();
        
    }
    public String getText(By by)
    {
        string value = null;
        
        IWebElement element=findElement(by);
        value = element.GetAttribute("value");
        if (value == null)
        {
            try
            {
                value = element.Text.ToString();
            }
            catch (Exception e)
            {
                value = null;
            }
        }
        return value;

    }

    public void sendKeys(By by,String text)
    {
        IWebElement element=findElement(by);
        element.Clear();
        waitBySec(2);
        element.SendKeys(text);
        waitBySec(2);
        Assert.AreEqual(getText(by),text);
    }

    public void failIfElementExist(By by)
    {
        Assert.False(doesElementExist(by),"found an element that shouldnt exist xpath: "+by.ToString());
    }
    
    public void failIfElementNotExist(By by)
    {
        Assert.True(doesElementExist(by),"found an element that shouldnt exist xpath: "+by.ToString());
    }
    public IWebElement findElement(By by)
    {
        IWebElement element=null;
        try
        {
            element = wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
        catch (Exception e)
        {
            Assert.Fail("Element did not found xpath = "+by.ToString());
        }
        return element;
    }
    public bool doesElementExist(By by)
    {
        IWebElement element=null;
        try
        {
            element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public void waitBySec(int sec)
    {
        Thread.Sleep(sec*1000);
    }
}