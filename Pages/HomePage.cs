using Automation.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
    public class HomePage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;

        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
        }

        List<IWebElement> elementsInHomePage => webDriver.FindElements(By.XPath("//div[@class='card mt-4 top-card']")).ToList();

        public void ClickOnOption(int indexOfElement)
        {
            if (indexOfElement < 0 || indexOfElement >= elementsInHomePage.Count)
            {
                Console.WriteLine($"The index {indexOfElement} doesn't exist. There are only {elementsInHomePage.Count},so the last index is {elementsInHomePage.Count - 1}");
            } 
            else
            {
                var h5Element = elementsInHomePage[indexOfElement].FindElement(By.TagName("h5"));
                Console.WriteLine(h5Element.Text);

                var element = elementsInHomePage[indexOfElement];

                ScrollToElement(element);

                element.Click();
            }

        }

        private void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

    }
}
