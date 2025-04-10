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

        public void SelectDateOfBirth()
        {
            var dateInput = webDriver.FindElement(By.Id("dateOfBirthInput"));

            // 1. Click pe input ca să deschizi calendarul
            dateInput.Click();

            // 2. Selectează luna "February" (value="1")
            var monthDropdown = webDriver.FindElement(By.ClassName("react-datepicker__month-select"));
            var selectMonth = new SelectElement(monthDropdown);
            selectMonth.SelectByText("February");

            // 3. Selectează anul "1967"
            var yearDropdown = webDriver.FindElement(By.ClassName("react-datepicker__year-select"));
            var selectYear = new SelectElement(yearDropdown);
            selectYear.SelectByText("1967");

            // 4. Click pe ziua 6 februarie (verificăm că are aria-label potrivit)
            var day6 = webDriver.FindElement(By.CssSelector("div.react-datepicker__day--006:not(.react-datepicker__day--outside-month)"));
            day6.Click();

            // 5. Verificare: inputul ar trebui să aibă acum valoarea "06 Feb 1967"
            string selectedDate = dateInput.GetAttribute("value");
            Console.WriteLine($"Data selectată: {selectedDate}");
        }


    }
}
