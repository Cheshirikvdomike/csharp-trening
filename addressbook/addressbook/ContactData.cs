using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook
{
    [TestFixture]
    public class ContactData:BaseClass
    {
        
        private StringBuilder verificationErrors;
        //private bool acceptNextAlert = true;
       // private PagesGroupData pagesGroupData = new PagesGroupData("", "", "", "Vasya", "Fedorov", "Vektor", "Horse and frogs", "123456789");

        [SetUp]
        public void SetupTest()
        {
            
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void CreateNewContacts()
        {
            GotoUrl();//Логин на сайт
            SetNewAttributes();//Установка аттрибутов для создания группы
        }


       

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

       

       
    }
}
