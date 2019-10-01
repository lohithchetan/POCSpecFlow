using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace POCAutomation.CustomMethods
{
    public static class CustomBaseClass
    {
        public static IWebDriver MyDriver { get; set; }

        // custom method for entering a text in to a field
        public static void EnterText(this IWebElement element, string value)
        {
            element.Click();
            element.Clear();
            element.SendKeys(value);
        }

        public static void EnterDropDownText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        // Custom Method for Selecting from a dropdown. we can specifty select type as Text, Value or Index
        public static void SelectFromDropDownByText(IWebElement element, string inputText)
        {
            //new SelectElement(element).SelectByText(inputValue);
            SelectElement se = new SelectElement(element);
            se.SelectByText(inputText);
        }
        public static void SelectFromDropDownByValue(IWebElement element, string inputValue)
        {
            //new SelectElement(element).SelectByValue(inputValue);
            SelectElement se = new SelectElement(element);
            se.SelectByValue(inputValue);
        }
        public static void SelectFromDropDownByIndex(IWebElement element, int index)
        {
            //new SelectElement(element).SelectByValue(inputValue);
            SelectElement se = new SelectElement(element);
            se.SelectByIndex(index);
        }

        // Custom Method for Drag and drop. we need to specify the origin element and destination elements
        public static void DragAndDropItem(IWebElement sourceElement, IWebElement destinationElement)
        {
           Actions action = new Actions(MyDriver);
            action.ClickAndHold(sourceElement).MoveToElement(destinationElement).Release().Build().Perform();
        }

        public static void ActionClick(this IWebElement Element)
        {
            Actions action = new Actions(MyDriver);
            action.MoveToElement(Element).Build().Perform();
        }
        public static void ActionHoverAndClick(this IWebElement ElementHover, IWebElement ElementClick)
        {
            Actions action = new Actions(MyDriver);
            action.MoveToElement(ElementHover);
            action.MoveToElement(ElementClick);
            action.Click().Build().Perform();
            Thinktime(2);
        }


        // This method removes all spaces present between the text that are inserted 
        // accidentaly by the user and converts the text to upper Case
        public static string TrimAllSpace(string Text)
        {
            return String.Join(" ", Text.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries));

        }

        public static void ScrollintoView(this IWebElement Element)
        {
            IJavaScriptExecutor js = MyDriver as IJavaScriptExecutor;
            // Run the javascript command 'scrollintoview on the element
            js.ExecuteScript("arguments[0].scrollIntoView(true);", Element);
            Thinktime(2);
        }

        // Method to click and verify page navigation 
        public static void ClickPageNavigation(IWebElement hyperlink, IWebElement landingPageObj)
        {
            try
            {
                hyperlink.Click();
                Thinktime(5);
               AssertClass.AssertElementIsPresent(landingPageObj);
            }catch (Exception ex){
                Console.WriteLine("Not able to navigate : {0}", ex.Message);
                throw ex;
            }

        }

        public static void Thinktime(int Time)
        {
            System.Threading.Thread.Sleep(Time * 1000);
        }

      
    }
}
