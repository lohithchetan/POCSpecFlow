using POCAutomation.CustomMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace POCAutomation.PageObjects
{
    public class LoginPage
    {
       public LoginPage()
       { PageFactory.InitElements(CustomBaseClass.MyDriver, this); }
        [FindsBy(How = How.XPath, Using = "(//span[contains (text(),'Sign in')])[1]")]public IWebElement linkSignIn { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='Username']")] public IWebElement inputUsername { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='Password']")] public IWebElement inputPassword { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@id='login_btn']")] public IWebElement loginButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@id='login_form']/div/div/ul/li")] public IWebElement invalidUserError { get; set; }
        [FindsBy(How=How.XPath, Using = "(//span[contains(text(),'Logout')])[1]")] public IWebElement signOutButton { get; set; }
        [FindsBy(How = How.XPath, Using = "(//a[contains(text(),'Quick View')])[1]")] public IWebElement linkQuickView { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@title='Add to Cart']")] public IWebElement buttonAddToCart { get; set; }

        String bookNamePath = "//h2[contains(text(),'";



        [FindsBy(How = How.XPath, Using = "//*[@id='nav-main']/ul/li[5]/a")] public IWebElement linkBooks { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@href='/shop/73']")] public IWebElement linkAgile { get; set; }
      

        // Enter username and Password
        public void LoginCredentials(string userName, string passWord)
        {
            try
            {
                inputUsername.Clear();
                inputUsername.EnterText(userName.Trim());
                inputPassword.Clear();
                inputPassword.EnterText(passWord.Trim());
            }
            catch (Exception E)
            {
                Console.WriteLine("Test Fail: did not enter username and password  : {0}", E.Message);
                throw;
            }
        }
        public void ClickLoginButton()
        {
            try
            {
                loginButton.Click();
            }
            catch (Exception E)
            {
                Console.WriteLine("Test Fail: did not click SignIn button  : {0}", E.Message);
                throw;
            }
        }
            public void ClickSignInLink()
        {
            try
            {
                linkSignIn.Click();
            }
            catch (Exception E)
            {
                Console.WriteLine("Test Fail: did not click SignIn link  : {0}", E.Message);
                throw;
            }

        }
        public void ClickSignOutButton()
        {
            try
            {
                
                signOutButton.Click();
            }
            catch (Exception E)
            {
                Console.WriteLine("Test Fail: did not click SignIn button  : {0}", E.Message);
                throw;
            }

        }


        public void quickViewBook(String BookName)
        {
            IWebElement bookHeader = CustomBaseClass.MyDriver.FindElement(By.XPath(bookNamePath + BookName + "')]"));
            bookHeader.Click();
            linkQuickView.Click();
           // CustomBaseClass.ActionHoverAndClick(bookHeader, linkQuickView);
        }

        public void NavigateToAgileBooks()
        {
            CustomBaseClass.ActionHoverAndClick(linkBooks, linkAgile);
           // Actions action = new Actions(CustomBaseClass.MyDriver);
           // action.MoveToElement(linkBooks);
            //action.MoveToElement(linkAgile);
            //action.Click().Build().Perform();

        }

        public void clickAddToCartButton()
        {
            buttonAddToCart.Click();
        }
    }
}
