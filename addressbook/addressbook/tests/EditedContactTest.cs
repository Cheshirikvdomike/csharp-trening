using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook.tests
{
    [TestFixture]
    public class EditedContactTest : BaseClass
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
        public void EditedContact()
        {
            ContactData contactData = new ContactData("Vasya", "Fedorov", "Vektor", "Horse and frogs", "123456789");
            LoginUserData loginUserData = new LoginUserData("admin", "secret", "http://localhost/addressbook");
            app.Contact.ReturnContactsPage()//Переходим на страницу контактов
                .BeginEdit()//Начинаем редактирование контакта
                .SetNewAttributes(contactData, "edit")//Установка аттрибутов для редактирования группы
                .ReturnContactsPage();//Переходим на страницу контактов
                app.login.Logout();

        }
    }
}
