using Automation.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
    public class CommonPage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;

        public CommonPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
        }

        List<IWebElement> elements => webDriver.FindElements(By.XPath("//span[@class='text']")).ToList();
       // public ElementMethods ElementMethods => elementMethods;

        public void GoToDesiredMenuItem(string menuName)
        {
            elementMethods.SelectElementFromListByText(elements, menuName);
            Console.WriteLine(menuName);
        }

        public void SelectDOB(string monthPick, string yearPick, string dayPick)
        {
            var dateSelected = webDriver.FindElement(By.Id("dateOfBirthInput"));

            dateSelected.Click();

            var selectMonthList = webDriver.FindElement(By.ClassName("react-datepicker__month-select"));
            var selectMonth = new SelectElement(selectMonthList);
            selectMonth.SelectByText(monthPick);

            var selectYearList = webDriver.FindElement(By.ClassName("react-datepicker__year-select"));
            var selectYear = new SelectElement(selectYearList);
            selectMonth.SelectByText(monthPick);

            var dayOfBirthSelect = webDriver.FindElement(By.CssSelector($"div.react-datepicker__day--0{dayPick}:not(.react-datepicker__day--oyside-month)"));
            dayOfBirthSelect.Click();
        }

    }
}
