using POCAutomation.CustomMethods;
using POCAutomation.PageObjects;
using POCAutomation.Resources;
using System;
using TechTalk.SpecFlow;

namespace POCAutomation.StepDefinations
{
    [Binding]
    public class LoginPageSteps
    {
        [Given(@"User navigated to application using (.*)")]
        public void GivenUserINavigatedToApplicationUsing(string BaseURL)
        {
            try
            {   
                    DriverClass.StartTest(TestConfig.clientUrl);
               
            }
            catch (Exception E)
            {
                Console.WriteLine("Test Failed: could not load the application : {0}", E.Message);
                DriverClass.CloseTest();
                throw;
            }
        }
        [When(@"User user clicks SignIn Link")]
        public void WhenUserUserClicksSignInLink()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.ClickSignInLink();
            CustomBaseClass.Thinktime(5);
        }


        [When(@"User login using credentials (.*) and (.*)")]
        public void WhenUserLoginUsingCredentialsAnd(string UserName, string PassWord)
        {
            
            LoginPage loginPage = new LoginPage();
            loginPage.LoginCredentials(UserName, PassWord);
            //System.Diagnostics.Debug.WriteLine(PassWord);
            loginPage.ClickLoginButton();
        }
        
        [Then(@"Client should be able to login successfully")]
        public void ThenClientShouldBeAbleToLoginSuccessfully()
        {
            try
            {
                LoginPage loginPage= new LoginPage();
                AssertClass.AssertElementIsPresent(loginPage.signOutButton);
                CustomBaseClass.Thinktime(5);
                //LoginPage loginPage = new LoginPage();
                // loginPage.NavigateToAgileBooks();
                //loginPage.linkBooks.Click();

            }
            catch (Exception E)
            {
                Console.WriteLine("Test Fail: did not landed to Welcome Page  : {0}", E.Message);
                ScreenShotsClass.FailedTestCaptureScreenShot("Login");
                DriverClass.CloseTest();
                throw;
            }
        }
        
        [Then(@"User should get (.*) message")]
        public void ThenUserShouldGetMessage(string error)
        {
            try
            {
                CustomBaseClass.Thinktime(10);
                LoginPage loginPage = new LoginPage();
                AssertClass.ContainsText(loginPage.invalidUserError, error);
                DriverClass.CloseTest();
            }
            catch(Exception E)
            {
                Console.WriteLine("Test Fail: Error message is incorrect: {0}", E.Message);
                DriverClass.CloseTest();
                throw;
            }

        }
        [When(@"Client click SignOut button")]
        public void WhenClientClickSignOutButton()
        {
            LoginPage loginPage = new LoginPage();
            CustomBaseClass.Thinktime(5);
            loginPage.ClickSignOutButton();
        }

        [Then(@"Client should be redirected to login page")]
        public void ThenClientShouldBeRedirectedToLoginPage()
        {
            LoginPage loginPage = new LoginPage();
            AssertClass.AssertElementIsPresent(loginPage.loginButton);
            DriverClass.CloseTest();
        }
        [Then(@"Test completed succesfully")]
        public void ThenTestCompletedSuccesfully()
        {
            DriverClass.CloseTest();
        }

        [When(@"User navigate to Agile Books Page")]
        public void WhenUserNavigateToAgileBooksPage()
        {
            CustomBaseClass.Thinktime(3);
            //HomePage homePage = new HomePage();
            //homePage.NavigateToAgileBooks();

            LoginPage loginPage = new LoginPage();
            loginPage.NavigateToAgileBooks();

        }
        [Then(@"Products should be displayed")]
        public void ThenProductsShouldBeDisplayed()
        {

        }

        [When(@"When used Click on Quick Overview link for (.*)")]
        public void WhenWhenUsedClickOnQuickOverviewLinkFor(String bookName)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.quickViewBook(bookName);
        }

        [When(@"User click on Add to Cart button")]
        public void WhenUserClickOnAddToCartButton()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.clickAddToCartButton();
        }

        [Then(@"Item Should get added to Cart")]
        public void ThenItemShouldGetAddedToCart()
        {
            CustomBaseClass.MyDriver.Close();
        }


    }
}
