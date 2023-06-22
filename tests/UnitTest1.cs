using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using StarkProject.pageObjectModel;
using StarkProject.utilities;
using System;
using System.Threading;

namespace StarkProject
{
    public class Tests:Base
    {
        

        [Test]
        public void Test1()
        {
            Thread.Sleep(3000);
           StarkHomePage SHP = new StarkHomePage(getDriver());
            SHP.selectFirstProduct();
            Thread.Sleep(5000);
            SHP.action();
           
          
            

           
            Thread.Sleep(5000);
            
            
            Assert.Pass();
        }
    }
}