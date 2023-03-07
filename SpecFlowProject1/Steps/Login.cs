using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject1.Hooks;

namespace SpecFlowProject1.Steps;
[Binding]
public class Login
{
    private By userNameTxtBx = By.XPath("//*[@placeholder='Username']");
    private By passwordTxtBx = By.XPath("//*[@placeholder='Password']");
    private By LoginButton = By.XPath("//*[@id='login-button']");

    private string loginErrorMessage =
        "//*[@data-test='error'][.='ERRMESSAGEHERE']";
    private By loginSuccesCheck = By.XPath("//*[@class='app_logo'][.='Swag Labs']");
    private Methods methods = new Methods();
        
    [Given("Enter User Name (.*)")]
    public void enterUserName(String userName)
    {
        methods.sendKeys(this.userNameTxtBx,userName);
    }
    
    [Given("Enter Password (.*)")]
    public void enterPassword(String Password)
    {
        methods.sendKeys(this.passwordTxtBx,Password);
        
    }
    
    [Given("Click Login Button")]
    public void clickLoginButton()
    {
        methods.click(LoginButton);
    }
    
    [Given("Check Error Message For Unsuccesfull Login (.*)")]
    public void checkErrorMessage(String message)
    {
        Assert.True(
            methods.doesElementExist(
                By.XPath(
                    loginErrorMessage
                        .Replace("ERRMESSAGEHERE",message))),
            "Error Message Did Not Found");
    }

    [Given("Check Succesfull Login")]
    public void checkSuccesfullLogin()
    {
        methods.waitBySec(2);
        Assert.True(
            methods.doesElementExist(loginSuccesCheck),
            "Unsuccesfull login");
        
    }
}