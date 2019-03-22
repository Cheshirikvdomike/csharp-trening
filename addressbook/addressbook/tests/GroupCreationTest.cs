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
    public class GroupCreationTest: BaseClass
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
            GroupData groupData = new GroupData("Name1", "Header1", "Footer1");
            LoginUserData loginUserData = new LoginUserData("admin", "secret", "http://localhost/addressbook");

            app.login.GotomyUrl(loginUserData);//Переход по Url, Логин на сайт
            app.Group.CreateNewGroup();//Начало создание новой группы
            app.Group.SetNewAttributesgroup(groupData);//Установка аттрибутов группы
            app.Group.AcceptChangesNewGroup();//Применение установленых аттрибутов
            app.Group.ControlNewGroup();//Переход на страницу групп
        }
    }
}
