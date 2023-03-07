using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject1.Hooks;

namespace SpecFlowProject1.Steps;
[Binding]
public class ProductList
{
    private String pruductByNumber = "//*[@class='inventory_list']/div[@class='inventory_item'][NUMBER]";
    private string producktButton = "//button[.='BUTTONNAME']";
    private string productPrice = "//*[@class='inventory_item_price']";
    private string productTitle = "//*[@class='inventory_item_name']";
    private string basketTitle = "//*[@class='inventory_item_name' and .='TITLEHERE']";
    private By basketBackBtn = By.XPath("//*[@name='continue-shopping']");
    private By basketBtn = By.XPath("//*[@class='shopping_cart_link']");
    private Methods methods = new Methods();
    private By checkOutBtn = By.XPath("//*[@id='checkout']");

    private static string selectedTitle;
 
    /*
     * This class contains methods for performing actions on the homepage
     */
    public By getProducktButton(String producktNumber, string buttonName)
    {
        //This method creates a by for button and returns it
        return By.XPath(
            (pruductByNumber+producktButton)
                .Replace("NUMBER",producktNumber)
                .Replace("BUTTONNAME",buttonName)
            );
    }

    public string getProducktTitleByNumber(string number)
    {
        // This Method reads and returns product title 
        By byOfElement = By.XPath((pruductByNumber + productTitle).Replace("NUMBER", number));
        string title = methods.getText(byOfElement);
        Console.WriteLine("removed produckt Title: "+title);
        return title;
        
    }

    public void addSelectedTitle(string title)
    {
        //adds title to memory
        selectedTitle = selectedTitle + "#" + title;
    }
    
    public void removeSelectedTitle(string title)
    {
        //removes title from memory
        selectedTitle = selectedTitle.Replace(title,"");
    }
    
    [Given("Click add button (.*)")]
    public void clickAddToCart(String producktNumber)
    {
        
        methods.click(
            getProducktButton(producktNumber,"Add to cart"));
        
        Assert.True(
            methods.doesElementExist(getProducktButton(producktNumber, "Remove")),
            "Remove button did not found");
        addSelectedTitle(getProducktTitleByNumber(producktNumber));
    }
    [Given("Click Remove button (.*)")]
    public void clickRemoveButton(String producktNumber)
    {
        
        methods.click(
            getProducktButton(producktNumber,"Remove"));
        
        Assert.True(
            methods.doesElementExist(getProducktButton(producktNumber, "Add to cart")),
            "Add to cart button did not found");
        removeSelectedTitle(getProducktTitleByNumber(producktNumber));

    }
    [Given("Click Basket")]
    public void clickBasketBtn()
    {
        methods.click(basketBtn);
        
        Assert.True(
            methods.doesElementExist(checkOutBtn),
            "Add to cart button did not found");
    }
    [Given("Check Basket Products")]
    public void checkBasketTitles()
    {
        String[] titles = (selectedTitle.Replace("##", "#")).Split("#");

        foreach (var oneTitle in titles)
        {
            if (oneTitle == null || oneTitle == "")
            {
                continue;
            }
            By by =By.XPath(basketTitle.Replace("TITLEHERE",oneTitle));
            Assert.True(methods.doesElementExist(by),"title did not found title: "+oneTitle);
            
        }
    }
    
    [Given("Click Back Basket Btn")]
    public void clickBackBasketBtn()
    {
        methods.click(basketBackBtn);
        Assert.True(
            methods.doesElementExist(
                getProducktButton("1","Add to cart"))
            ,"Back Button Does Not Work");
    }
    
}