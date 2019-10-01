using POCAutomation.PageObjects;
using POCAutomation.CustomMethods;
using POCAutomation.Resources;
using System;
using TechTalk.SpecFlow;


namespace POCAutomation.StepDefinations
{
    [Binding]
    class HomePageSteps
    {
        [When(@"User navigate to Agile Books Page")]
        public void WhenUserNavigateToAgileBooksPage()
        {
            HomePage homePage = new HomePage();
            homePage.NavigateToAgileBooks();

        }
        [Then(@"Products should be displayed")]
        public void ThenProductsShouldBeDisplayed()
        {
            
        }

        [When(@"When used Click on Quick Overview link for (.*)")]
        public void WhenWhenUsedClickOnQuickOverviewLinkFor(String bookName)
        {
            HomePage homePage = new HomePage();
            homePage.quickViewBook(bookName);
        }

        [When(@"User click on Add to Cart button")]
        public void WhenUserClickOnAddToCartButton()
        {
            HomePage homePage = new HomePage();
            homePage.clickAddToCartButton();
        }

        [Then(@"Item Should get added to Cart")]
        public void ThenItemShouldGetAddedToCart()
        {
            
        }


    }
}
