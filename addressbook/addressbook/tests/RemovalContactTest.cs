using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook.tests
{
    [TestFixture]
    public class RemovalContactTest : AuthTestBase
    {
        private StringBuilder verificationErrors;
        [SetUp]
        public void SetupTest()
        {
            verificationErrors = new StringBuilder();
        }
        
        [Test]
        public void DeleteContact()
        {
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.ReturnContactsPage()//Переходим на страницу контактов
                .SelectContact(0)//Выбираем контакт
                .DeletedContact()//Удаляем контакт
                .CloseAlert()//Подтверждаем удаление
                .ReturnContactsPage();//Переходим на страницу контактов
            List<ContactData> newConacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newConacts);
            app.login.Logout();

        }
    }
}
