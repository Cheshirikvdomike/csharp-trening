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
    public class Groupdata: BaseClass
    {
        private StringBuilder verificationErrors;
        
        private bool acceptNextAlert = true;

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
        public void CreateNewGroups()
        {
            GotoUrl();//Переход по Url, Логин на сайт
            CreateNewGroup();//Начало создание новой группы
            SetNewAttributes();//Установка аттрибутов группы
            AcceptChangesNewGroup();//Применение установленых аттрибутов
            ControlNewGroup();//Переход на страницу групп
        }

        
      

       

       

        

    


    }
}
