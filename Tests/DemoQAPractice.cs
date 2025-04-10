using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Automation.HelperMethods;
using Automation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Automation
{
    public class DemoQAPractice
    {

        IWebDriver webDriver;
        HomePage homePage;
        CommonPage commonPage;

        [Test]
        public void ClickOnOneCardFromHomePageMethod()
        {
            webDriver = new ChromeDriver();

            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            homePage = new HomePage(webDriver);
            commonPage = new CommonPage(webDriver);

            homePage.ClickOnOption(1);
 
        }

        [Test]
        public void PracticeFormsDatePickerMethod() 
        {
            
            webDriver = new ChromeDriver();

            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            commonPage = new CommonPage(webDriver);
            homePage = new HomePage(webDriver);

            homePage.ClickOnOption(1);

            commonPage.GoToDesiredMenuItem("Practice Form");

            commonPage.SelectDateOfBirth();

        }

        [TearDown]
        public void TearDown()
        {
            System.Threading.Thread.Sleep(2000);
            webDriver.Dispose();
            webDriver.Quit();
        }
    }
}
