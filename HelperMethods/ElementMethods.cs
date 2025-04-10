using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Automation.HelperMethods
{
    public class ElementMethods(IWebDriver driver)
    {
        private IWebDriver Driver = driver;

        public void ClickOnElement(IWebElement element)
        {
            element.Click();
        }

        public void FillElement(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public void SelectElementFromListByText(IList<IWebElement> elementList, string text)
        {
            foreach (IWebElement element in elementList)
            {
                if (element.Text == text)
                {
                    ClickOnElement(element);
                }
            }
        }

    }
}
