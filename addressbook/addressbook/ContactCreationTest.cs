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
    public class ContactCreationTest:BaseClass
    {
        
        private StringBuilder verificationErrors;
       

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
            LoginUserData loginUserData = new LoginUserData("admin", "secret", "http://localhost/addressbook");
            ContactData contactData = new ContactData("Vasya", "Fedorov", "Vektor", "Horse and frogs", "123456789");
            loginHelper.GotomyUrl(loginUserData);//Логин на сайт
            contactHelper.SetNewAttributes(contactData);//Установка аттрибутов для создания группы
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
