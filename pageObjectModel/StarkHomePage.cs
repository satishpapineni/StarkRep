using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StarkProject.pageObjectModel
{
    public class StarkHomePage
    {
        public IWebDriver driver;
        public StarkHomePage(IWebDriver driver)//created a single parameter constructor
        {
            this.driver = driver;//assigning global variable to local variable.
            PageFactory.InitElements(driver, this);//import pageobject package.// allocating driver and memory to that driver.
        }
        [FindsBy(How = How.Id, Using = "autosuggest__input")]//import page factory package to define webelements.
         IWebElement searchBox;
        
        
        
        
       
        public void  selectFirstProduct()//created a method to send the values.
        {
            // bool textBox=searchBox.Enabled;
            if (searchBox.Enabled)//if searchbox is enable the it goes inside and send the values and click the seacrh button.
            {
                searchBox.SendKeys("lampe");

              

            }
            else
            {
                Console.WriteLine("failed");
            }


        }
        public void action()
        {
            IWebElement sb=driver.FindElement(By.Id("autosuggest__input"));
            
            Actions a=new Actions(driver);
            //a.DoubleClick(sb).Click().Build().Perform();
            a.MoveToElement(driver.FindElement(By.Id("autosuggest__input"))).Click().SendKeys(Keys.Enter).Build().Perform();
            driver.FindElement(By.XPath("//div[normalize-space()='RAPTOR LED Arbejdslampe Genopladelig']")).Click();
            driver.FindElement(By.XPath("//span[@class='icon_basket icon-size-22 icon-pr-8 space-nowrap']")).Click();
            driver.FindElement(By.XPath("//input[@class='textfield w-100 maxwidth-160 mr-2']")).SendKeys("2670");
            driver.FindElement(By.XPath("//button[normalize-space()='Vælg']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//button[normalize-space()='Gå til kurven']")).Click();   
                
        }


    }
}

