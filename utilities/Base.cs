using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace StarkProject.utilities
{
    public  class Base
    {
        string actualUrl = "https://www.stark.dk/";
        public IWebDriver driver;
        [SetUp]

        public void Setup()
        {
            string browserName = ConfigurationManager.AppSettings["browser"];
            InItBrowser(browserName);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(actualUrl);
            driver.FindElement(By.XPath("//button[@onclick='CookieInformation.submitAllCategories();']")).Click();
            string expectedUrl = driver.Url;
            Console.WriteLine(actualUrl);
            Console.WriteLine(expectedUrl);
            Assert.AreEqual(expectedUrl, actualUrl);
        }
        public void InItBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;

            }
        }
        public IWebDriver getDriver()
        {
            return driver;
        }
        [TearDown]
        public void shutDownBrowser()
        {
            
            driver.Close();
        }
    }
}
