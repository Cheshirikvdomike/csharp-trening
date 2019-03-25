using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook.tests
{
    [TestFixture]
    public class RemovalContactTest : BaseClass
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
        public void DeleteContact()
        {
            LoginUserData loginUserData = new LoginUserData("admin", "secret", "http://localhost/addressbook");
            app.Contact.ReturnContactsPage()//Переходим на страницу контактов
                .SelectContact()//Выбираем контакт
                .DeletedContact()//Удаляем контакт
                .CloseAlert()//Подтверждаем удаление
                .ReturnContactsPage();//Переходим на страницу контактов
            app.login.Logout();

        }
    }
}
