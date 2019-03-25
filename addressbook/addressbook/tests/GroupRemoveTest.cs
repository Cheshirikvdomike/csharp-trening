using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook.tests
{
    [TestFixture]
  public class GroupRemoveTest: BaseClass
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
        public void GroupRemovalTest()
        {
            LoginUserData loginUserData = new LoginUserData("admin", "secret", "http://localhost/addressbook");
            app.login.GotomyUrl(loginUserData);//Переход по Url, Логин на сайт
            app.Group.SelectGroupSection()//Переходим в раздел Groups
                .SelectGroup()//Выбираем группу
                .RemoveGroup()//Удаляем первую выбранную группу
                .SelectGroupSection();//Возвращаемся в раздел групп
            app.login.Logout();//Разлогиниваемся

        }
    }
}
